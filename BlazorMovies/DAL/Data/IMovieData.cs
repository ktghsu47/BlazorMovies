using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorMovies.Shared.Entities;

namespace BlazorMovies.DAL.Data {
	public interface IMovieData {
		Task<int> CreateMovie(Movie movie);
		Task<int> CreateMovieActor(MovieActor movieActor);
		Task<int> CreateMovieGenre(MovieGenre movieGenre);
		Task<int> CreateMovieRating(MovieRating movieRating);
		Task<int> DeleteMovie(int id);
		Task<List<Person>> GetActorsByMovieId(int musicId);
		Task<List<Genre>> GetGenresByMusicId(int musicId);
		Task<double> GetMovieAverage(int movieId);
		Task<Movie> GetMovieById(int id);
		Task<List<Movie>> GetMovies();
		Task<List<Movie>> GetMoviesInTheaters(int limit = 10);
		Task<List<Movie>> GetMoviesUpcoming(int limit = 10);
		Task<MovieRating> GetMovieUserRate(int userId, int movieId);
		Task UpdateMovie(Movie movie);
		Task UpdateMovieRating(int id, int rate);
	}
}