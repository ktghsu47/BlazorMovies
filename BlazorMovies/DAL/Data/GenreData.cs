using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using BlazorMovies.DAL.Db;
using BlazorMovies.Shared.Entities;
using Dapper;

namespace BlazorMovies.DAL.Data {
	public class GenreData: IGenreData {
        private readonly IDataAccess _dataAccess;

        public GenreData(IDataAccess dataAccess) {
            _dataAccess = dataAccess;
        }

        public async Task<int> CreateGenre(Genre genre) {
            var dp = new DynamicParameters();

            dp.Add("Name", genre.Name);
            dp.Add("Id", DbType.Int32, direction: ParameterDirection.Output);

            await _dataAccess.SaveData("dbo.spGenres_Create", dp);

            return dp.Get<int>("Id");
        }

        public async Task<int> DeleteGenre(int id) {
            return await _dataAccess.SaveData("dbo.spGenres_Delete", new { id });
        }

        public async Task<Genre> GetGenreById(int id) {
            var rows = await _dataAccess.LoadData<Genre, dynamic>("dbo.spGenres_GetById", new { id });

            return rows.FirstOrDefault();
        }

        public async Task<List<Genre>> GetGenres() {
            return await _dataAccess.LoadData<Genre, dynamic>("spGenres_All", new { });
        }

        public async Task UpdateGenre(int id, string name) {
            await _dataAccess.SaveData("dbo.spGenres_Update", new { id, name });
        }
    }
}