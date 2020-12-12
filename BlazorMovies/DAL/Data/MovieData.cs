using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using BlazorMovies.DAL.Db;
using BlazorMovies.Shared.Entities;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace BlazorMovies.DAL.Data {
	public class MovieData : IMovieData {
		private readonly IDataAccess _dataAccess;
		private readonly IConfiguration _config;

		public MovieData(IDataAccess dataAccess, IConfiguration config) {
			_dataAccess = dataAccess;
			_config = config;
		}

		public async Task<int> CreateMovie(Movie movie) {
			var dp = new DynamicParameters();

			dp.Add("Title", movie.Title);
			dp.Add("Summary", movie.Summary);
			dp.Add("InTheaters", movie.InTheaters);
			dp.Add("Trailer", movie.Trailer);
			dp.Add("Poster", movie.Poster);
			dp.Add("Id", DbType.Int32, direction: ParameterDirection.Output);

			await _dataAccess.SaveData("dbo.spMovies_Create", dp);

			return dp.Get<int>("Id");
		}

		public async Task<int> CreateMovieActor(MovieActor movieActor) {
			var dp = new DynamicParameters();

			dp.Add("PersonId", movieActor.PersonId);
			dp.Add("MovieId", movieActor.MovieId);
			dp.Add("Character", movieActor.Character);
			dp.Add("Order", movieActor.Order);
			dp.Add("Id", DbType.Int32, direction: ParameterDirection.Output);

			await _dataAccess.SaveData("dbo.spMovieActors_Create", dp);

			return dp.Get<int>("Id");
		}

		public async Task<int> CreateMovieGenre(MovieGenre movieGenre) {
			var dp = new DynamicParameters();

			dp.Add("GenreId", movieGenre.GenreId);
			dp.Add("MovieId", movieGenre.MovieId);
			dp.Add("Id", DbType.Int32, direction: ParameterDirection.Output);

			await _dataAccess.SaveData("dbo.spMovieGenres_Create", dp);

			return dp.Get<int>("Id");
		}

		public async Task<int> CreateMovieRating(MovieRating movieRating) {
			var dp = new DynamicParameters();

			dp.Add("MovieId", movieRating.MovieId);
			dp.Add("UserId", movieRating.UserId);
			dp.Add("Rate", movieRating.Rate);
			dp.Add("Id", DbType.Int32, direction: ParameterDirection.Output);

			await _dataAccess.SaveData("dbo.spMovieRatings_Create", dp);

			return dp.Get<int>("Id");
		}

		public async Task<int> DeleteMovie(int id) {
			return await _dataAccess.SaveData("dbo.spMovies_Delete", new { id });
		}

		public async Task<List<Person>> GetActorsByMovieId(int id) {
			return await _dataAccess.LoadData<Person, dynamic>("spMovies_GetActorsByMovieId", new { id });
		}

		public async Task<List<Genre>> GetGenresByMusicId(int id) {
			return await _dataAccess.LoadData<Genre, dynamic>("spMovies_GetGenresByMovieId", new { id });
		}

		public async Task<double> GetMovieAverage(int movieId) {
			var rows = await _dataAccess.LoadData<double, dynamic>("spMovieRatings_GetAverage",new { movieId });

			return rows.FirstOrDefault();
		}

		public async Task<Movie> GetMovieById(int id) {
			Movie movie = null;
			List<MovieGenre> movieGenres = null;
			List<MovieActor> movieActors = null;
			var dp = new DynamicParameters();
			dp.Add("@id", id);

			using (IDbConnection cnn = new SqlConnection(_config.GetConnectionString("Default"))) {
				using (var lists = await cnn.QueryMultipleAsync("spMovies_GetById", dp, null, null, CommandType.StoredProcedure)) {
					movie = lists.Read<Movie>().SingleOrDefault();
					movieGenres = lists.Read<MovieGenre>().ToList();
					movieActors = lists.Read<MovieActor>().ToList();
				}
			}

			if (movie != null) {
				movie.MovieGenres = movieGenres;
				movie.MovieActors = movieActors;
			}

			return movie;
		}

		public async Task<List<Movie>> GetMovies() {
			var Movies = await _dataAccess.LoadData<Movie, dynamic>("spMovies_All", new { });
			var newMovies = new List<Movie>();

			foreach (var movie in Movies) {
				newMovies.Add(await GetMovieById(movie.Id));
			}

			return newMovies;
		}

		public async Task<List<Movie>> GetMoviesInTheaters(int limit = 10) {
			var Movies = await _dataAccess.LoadData<Movie, dynamic>("spMovies_InTheaters", new { limit });
			var newMovies = new List<Movie>();

			foreach (var movie in Movies) {
				newMovies.Add(await GetMovieById(movie.Id));
			}

			return newMovies;
		}

		public async Task<List<Movie>> GetMoviesUpcoming(int limit = 10) {
			var Movies = await _dataAccess.LoadData<Movie, dynamic>("spMovies_Upcoming", new { limit });
			var newMovies = new List<Movie>();

			foreach (var movie in Movies) {
				newMovies.Add(await GetMovieById(movie.Id));
			}

			return newMovies;
		}

		public async Task<MovieRating> GetMovieUserRate(int userId, int movieId) {
			var rows = await _dataAccess.LoadData<MovieRating, dynamic>("spMovieRatings_GetUserRate", new { userId, movieId });

			return rows.FirstOrDefault();
		}

		public async Task UpdateMovieRating(int id, int rate) {
			await _dataAccess.SaveData("spMovieRatings_Update", new { id, rate });
		}

		public async Task UpdateMovie(Movie movie) {
			var dp = new DynamicParameters();

			dp.Add("Id", movie.Id);
			dp.Add("Title", movie.Title);
			dp.Add("Summary", movie.Summary);
			dp.Add("InTheaters", movie.InTheaters);
			dp.Add("Trailer", movie.Trailer);
			dp.Add("ReleaseDate", movie.ReleaseDate);
			dp.Add("Poster", movie.Poster);
			dp.Add("Id", DbType.Int32, direction: ParameterDirection.Output);

			await _dataAccess.SaveData("dbo.spUsers_Update", dp);
		}
	}
}