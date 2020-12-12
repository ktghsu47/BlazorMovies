using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorMovies.DAL.Db;
using BlazorMovies.Shared.Entities;

namespace BlazorMovies.DAL.Data {
	class RoleData : IRoleData {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connect;

        public RoleData(IDataAccess dataAccess, ConnectionStringData connectionString) {
            _dataAccess = dataAccess;
            _connect = connectionString;
        }

        public async Task<List<Role>> GetRoles() {
            return await _dataAccess.LoadData<Role, dynamic>(
                "spRoles_All",
                new { },
                _connect.SqlConnectionName
            );
        }
	}
}
