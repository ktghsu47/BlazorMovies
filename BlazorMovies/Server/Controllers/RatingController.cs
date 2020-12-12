using System.Security.Claims;
using System.Threading.Tasks;
using BlazorMovies.DAL.Data;
using BlazorMovies.Shared.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlazorMovies.Server.Controllers {
	[ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class RatingController : ControllerBase {
        private readonly IMovieData _repo;

        public RatingController(IMovieData movieData) {
            _repo = movieData;
        }

        [HttpPost]
        public async Task<ActionResult> Rate(MovieRating movieRating) {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var currentRating = await _repo.GetMovieUserRate(userId, movieRating.MovieId);

            if (currentRating == null) {
                movieRating.UserId = userId.ToString();
                await _repo.CreateMovieRating(movieRating);
            } else {
                await _repo.UpdateMovieRating(currentRating.Id, movieRating.Rate);
            }

            return NoContent();
        }
    }
}