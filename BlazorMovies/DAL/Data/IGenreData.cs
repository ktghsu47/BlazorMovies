using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorMovies.Shared.Entities;

namespace BlazorMovies.DAL.Data {
	public interface IGenreData {
        Task<int> CreateGenre(Genre genre);
        Task<int> DeleteGenre(int id);
        Task<Genre> GetGenreById(int id);
        Task<List<Genre>> GetGenres();
        Task UpdateGenre(int id, string name);
    }
}