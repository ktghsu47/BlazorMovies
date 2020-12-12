using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorMovies.Shared.DTOs;
using BlazorMovies.Shared.Entities;

namespace BlazorMovies.Client.Repository {
	public interface IPersonRepository {
        Task CreatePerson(Person person);
        Task DeletePerson(int Id);
        Task<PagingDTO<List<Person>>> GetPeople(PageNumberSizeDTO pageNumberSizeDTO);
        Task<List<Person>> GetPeopleByName(string name);
        Task<Person> GetPersonById(int id);
        Task UpdatePerson(Person person);
    }
}