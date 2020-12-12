using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorMovies.Shared.Entities;

namespace BlazorMovies.DAL.Data {
	public interface IUserData {
		Task AssignUserRole(int userId, string roleName);
		Task<int> CreatePerson(Person person);
		Task<int> DeletePerson(int id);
		Task<List<Person>> GetPeople();
		Task<Person> GetPersonById(int id);
		Task<Role> GetRole(int userId);
		Task<List<Role>> GetRoles();
		Task<Person> Login(string email, string password);
		Task<int> Register(string email, string password);
		Task RemoveUserRole(int userId, string roleName);
		Task<List<Person>> SearchPeople(int limt, string searchText);
		Task<int> UpdatePerson(Person person);
	}
}