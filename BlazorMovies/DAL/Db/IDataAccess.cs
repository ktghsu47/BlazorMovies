using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorMovies.DAL.Db {
    public interface IDataAccess {
        Task<List<T>> LoadData<T, U>(string storedProcedure, U parameters);
        Task<int> SaveData<T>(string storedProcedure, T parameters);

        Task ExecuteCommand<T>(string sql, T parameters);
        Task<List<T>> Query<T, U>(string sql, U parameters);
        Task<T> QuerySingle<T, U>(string sql, U parameters);
    }
}