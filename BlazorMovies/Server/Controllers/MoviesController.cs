using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BlazorMovies.DAL.Data;
using BlazorMovies.Server.Helpers;
using BlazorMovies.Shared.DTOs;
using BlazorMovies.Shared.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BlazorMovies.Server.Controllers {
	[ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    public class MoviesController : ControllerBase {
        private readonly IMovieData _repo;
        private readonly IGenreData _repo1;
        private readonly IConfiguration _config;
        private readonly IFileStorageService _fileStorageService;
        private string containerName = "movies";

        public MoviesController(IMovieData movieData, IGenreData genreData, IConfiguration configuration, IFileStorageService fileStorageService) {
            _repo = movieData;
            _repo1 = genreData;
            _config = configuration;
            _fileStorageService = fileStorageService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IndexPageDTO>> Get() {
            //var limit = Convert.ToInt32(_config["AppSettings:Limit"]);
            var limit = Convert.ToInt32(_config.GetSection("AppSettings:Limit").Value);
            var moviesInTheaters = await _repo.GetMoviesInTheaters(limit);
            var upcomingReleases = await _repo.GetMoviesUpcoming(limit);

            return new IndexPageDTO {
                InTheaters = moviesInTheaters,
                UpcomingReleases = upcomingReleases
            };
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<DetailsMovieDTO>> Get(int id) {
            var movie = await _repo.GetMovieById(id);
            if (movie == null) { return NotFound(); }

            var detailsMovieDTO = new DetailsMovieDTO();
            if (User.FindFirst(ClaimTypes.NameIdentifier) != null) {
                var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                var userRate = (await _repo.GetMovieUserRate(userId, id));

                detailsMovieDTO.UserVote = userRate == null ? 0 : userRate.Rate;
			} else {
                detailsMovieDTO.UserVote = 0;
            }

            detailsMovieDTO.Movie = movie;
            detailsMovieDTO.AverageVote = await _repo.GetMovieAverage(id);
            detailsMovieDTO.Genres = await _repo.GetGenresByMusicId(id);
            detailsMovieDTO.Actors = await _repo.GetActorsByMovieId(id);

            return detailsMovieDTO;
        }

        [HttpPost("filter")]
        [AllowAnonymous]
        public async Task<ActionResult<List<Movie>>> Filter(FilterMoviesDTO filterMoviesDTO) {
            var moviesQueryable = (await _repo.GetMovies()).AsQueryable();

            if (!string.IsNullOrWhiteSpace(filterMoviesDTO.Title)) {
                moviesQueryable = moviesQueryable.Where(x => x.Title.ToLower().Contains(filterMoviesDTO.Title.ToLower()));
            }

            if (filterMoviesDTO.InTheaters) {
                moviesQueryable = moviesQueryable.Where(x => x.InTheaters);
            }

            if (filterMoviesDTO.UpcomingReleases) {
                var today = DateTime.Today;
                moviesQueryable = moviesQueryable.Where(x => x.ReleaseDate > today);
            }

            if (filterMoviesDTO.GenreId != 0) {
                moviesQueryable = moviesQueryable
                    .Where(x => x.MovieGenres.Select(y => y.GenreId)
                    .Contains(filterMoviesDTO.GenreId));
            }

            HttpContext.InsertPageTotalInHeader(moviesQueryable, filterMoviesDTO.PageSize);

            return moviesQueryable.Paginate(filterMoviesDTO.PageNumberSizeDTO).ToList();
        }

        [HttpGet("update/{id}")]
        public async Task<ActionResult<MovieUpdateDTO>> PutGet(int id) {
            var movieActionResult = await Get(id);
            if (movieActionResult.Result is NotFoundResult) { return NotFound(); }

            var movieDetailDTO = movieActionResult.Value;
            var selectedGenresIds = movieDetailDTO.Genres.Select(x => x.Id).ToList();
            var notSelectedGenres = (await _repo1.GetGenres()).Where(x => !selectedGenresIds.Contains(x.Id)).ToList();
            var movieUpdateDTO = new MovieUpdateDTO {
                Movie = movieDetailDTO.Movie,
                SelectedGenres = movieDetailDTO.Genres,
                NotSelectedGenres = notSelectedGenres,
                Actors = movieDetailDTO.Actors
            };

            return movieUpdateDTO;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Movie movie) {
            if (!string.IsNullOrWhiteSpace(movie.Poster)) {
                var poster = Convert.FromBase64String(movie.Poster);
                movie.Poster = await _fileStorageService.SaveFile(poster, "jpg", containerName);
            }

            if (movie.MovieActors != null) {
                for (int i = 0; i < movie.MovieActors.Count; i++) {
                    movie.MovieActors[i].Order = i + 1;
                }
            }

            await _repo.CreateMovie(movie);

            return movie.Id;
        }

        [HttpPut]
        public async Task<ActionResult> Put(Movie movie) {
            var movieDB = await _repo.GetMovieById(movie.Id);
            if (movieDB == null) { return NotFound(); }

            await _repo.DeleteMovie(movie.Id);
            await Post(movie);

            if (!string.IsNullOrWhiteSpace(movie.Poster)) {
				var moviePoster = Convert.FromBase64String(movie.Poster);
				movieDB.Poster = await _fileStorageService.EditFile(moviePoster, "jpg", containerName, movieDB.Poster);
			}

			if (movie.MovieActors != null) {
                var i = 0;
				foreach (var movieActor in movie.MovieActors) {
                    movieActor.Order = i + 1;
                    await _repo.CreateMovieActor(movieActor);
                    i++;
                }
			}

            if (movie.MovieGenres != null) {
                foreach (var movieGenre in movie.MovieGenres) {
                    await _repo.CreateMovieGenre(movieGenre);
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id) {
            var movie = await _repo.GetMovieById(id);
            if (movie == null) { return NotFound(); }

            await _repo.DeleteMovie(id);

            return NoContent();
        }
    }
}