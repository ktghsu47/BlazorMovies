using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorMovies.DAL.Data;
using BlazorMovies.Shared.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlazorMovies.Server.Controllers {
	[ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    public class GenresController : ControllerBase {
        private readonly IGenreData _repo;

        public GenresController(IGenreData genreData) {
            _repo = genreData;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<Genre>>> Get() {
            return await _repo.GetGenres();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Genre>> Get(int id) {
            var genre = await _repo.GetGenreById(id);
            if (genre == null) { return NotFound(); }

            return genre;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Genre genre) {
            return await _repo.CreateGenre(genre);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Genre genre) {
            await _repo.UpdateGenre(genre.Id, genre.Name); ;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id) {
            var genre = await _repo.GetGenreById(id);

            if (genre == null) { return NotFound(); }

            await _repo.DeleteGenre(id);

            return NoContent();
        }
    }
}