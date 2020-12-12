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
	public class UserData : IUserData {
        private readonly IDataAccess _dataAccess;
        private readonly IConfiguration _config;

        public UserData(IDataAccess dataAccess, IConfiguration config) {
            _dataAccess = dataAccess;
            _config = config;
        }

        public async Task AssignUserRole(int id, string roleName) {
            var dp = new DynamicParameters();

            dp.Add("Id", id);
            dp.Add("RoleName", roleName);

            await _dataAccess.SaveData("spRoles_Create", dp);
        }

        public async Task<int> CreatePerson(Person person) {
            var dp = new DynamicParameters();

            dp.Add("RoleId", person.RoleId);
            dp.Add("Email", person.Email);
            dp.Add("Password", person.Password);
            dp.Add("Name", person.Name);
            dp.Add("Biography", person.Biography);
            dp.Add("Picture", person.Picture);
            dp.Add("DateOfBirth", person.DateOfBirth);
            dp.Add("Id", DbType.Int32, direction: ParameterDirection.Output);

            await _dataAccess.SaveData("dbo.spUsers_Create", dp);

            return dp.Get<int>("Id");
        }

        public async Task<int> DeletePerson(int id) {
            return await _dataAccess.SaveData("dbo.spUsers_Delete", new { id });
        }

        public async Task<List<Person>> GetPeople() {
            //return await _dataAccess.LoadData<Person, dynamic>("spUsers_All", new { });
            var people = await _dataAccess.LoadData<Person, dynamic>("spUsers_All", new { });
            var newPeople = new List<Person>();

            foreach (var person in people) {
                newPeople.Add(await GetPersonById(person.Id));
            }

            return newPeople;
        }

        public async Task<Person> GetPersonById(int id) {
            //var rows = await _dataAccess.LoadData<Person, dynamic> "spUsers_GetById", new { id });

            //return rows.FirstOrDefault();
            Person person = null;
            List<MovieActor> movieActors = null;
            var p = new DynamicParameters();
            p.Add("@id", id);

            using (IDbConnection cnn = new SqlConnection(_config.GetConnectionString("Default"))) {
                using (var lists = await cnn.QueryMultipleAsync("spUsers_GetById", p, null, null, CommandType.StoredProcedure)) {
                    person = lists.Read<Person>().SingleOrDefault();
                    movieActors = lists.Read<MovieActor>().ToList();
                }
            }

            if (person != null) {
                person.MovieActors = movieActors;
            }

            return person;
        }

        public async Task<Role> GetRole(int id) {
            var rows = await _dataAccess.LoadData<Role, dynamic>("spRoles_GetRoleByUserId", new { id });

            return rows.FirstOrDefault();
        }

        public async Task<List<Role>> GetRoles() {
            return await _dataAccess.LoadData<Role, dynamic>("spRoles_All", new { });
        }

        public async Task<Person> Login(string email, string password) {
            var rows = await _dataAccess.LoadData<Person, dynamic>("spUsers_Login", new { email, password });

            return rows.FirstOrDefault();
        }

		public async Task<int> Register(string email, string password) {
            var dp = new DynamicParameters();

            dp.Add("Email", email);
            dp.Add("Password", password);
            dp.Add("Id", DbType.Int32, direction: ParameterDirection.Output);

            await _dataAccess.SaveData("spUsers_Delete", dp);

            return dp.Get<int>("Id");
        }

        public async Task RemoveUserRole(int id, string roleName) {
            var dp = new DynamicParameters();

            dp.Add("Id", id);
            dp.Add("RoleName", roleName);

            await _dataAccess.SaveData("spRoles_Create", dp);
        }

        public async Task<List<Person>> SearchPeople(int limt, string searchText) {
            return await _dataAccess.LoadData<Person, dynamic>("spUsers_Search", new { limt, searchText });
        }

        public async Task<int> UpdatePerson(Person person) {
            var dp = new DynamicParameters();

            dp.Add("Id", person.Id);
            dp.Add("RoleId", person.RoleId);
            dp.Add("Email", person.Email);
            dp.Add("Password", person.Password);
            dp.Add("Name", person.Name);
            dp.Add("Biography", person.Biography);
            dp.Add("Picture", person.Picture);
            dp.Add("DateOfBirth", person.DateOfBirth);
            dp.Add("Id", DbType.Int32, direction: ParameterDirection.Output);

            await _dataAccess.SaveData("dbo.spUsers_Update", dp);

            return person.Id;
        }
    }
}