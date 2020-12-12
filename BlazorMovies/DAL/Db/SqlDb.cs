using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;

namespace BlazorMovies.DAL.Db {
	public class SqlDb : IDataAccess {
        private readonly string _connectionString;

        public SqlDb(string connectionString) {
            _connectionString = connectionString;
        }

        public async Task<List<T>> LoadData<T, U>(string storedProcedure, U parameters) {
            using (IDbConnection connection = new SqlConnection(_connectionString)) {
                var rows = await connection.QueryAsync<T>(
                    storedProcedure,
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return rows.ToList();
            }
        }

        public async Task<int> SaveData<T>(string storedProcedure, T parameters) {
            using (IDbConnection connection = new SqlConnection(_connectionString)) {
                return await connection.ExecuteAsync(
                    storedProcedure,
                    parameters,
                    commandType: CommandType.StoredProcedure
                );
            }
        }

        public async Task<List<T>> Query<T, U>(string sql, U parameters) {
            using (IDbConnection conn = new SqlConnection(_connectionString)) {
                return (List<T>)await conn.QueryAsync<T>(sql, parameters);
            }
        }

        public async Task<T> QuerySingle<T, U>(string sql, U parameters) {
            using (IDbConnection conn = new SqlConnection(_connectionString)) {
                return await conn.QuerySingleAsync<T>(sql, parameters);
            }
        }

        public async Task ExecuteCommand<T>(string sql, T parameters) {
            using (IDbConnection conn = new SqlConnection(_connectionString)) {
                await conn.ExecuteAsync(sql, parameters);
            }
        }
	}
}