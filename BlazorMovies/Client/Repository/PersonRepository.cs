using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorMovies.Client.Helpers;
using BlazorMovies.Shared.DTOs;
using BlazorMovies.Shared.Entities;

namespace BlazorMovies.Client.Repository {
	public class PersonRepository : IPersonRepository {
        private readonly IHttpService _http;
        private readonly string baseURL = "api/people";

        public PersonRepository(IHttpService httpService) {
            _http = httpService;
        }

        public async Task<PagingDTO<List<Person>>> GetPeople(PageNumberSizeDTO pageNumberSizeDTO) {
            return await _http.GetPaging<List<Person>>(baseURL, pageNumberSizeDTO);
        }

        public async Task<List<Person>> GetPeopleByName(string name) {
            var httpResponseWrapper = await _http.Get<List<Person>>($"{baseURL}/search/{name}");
            
            if (!httpResponseWrapper.IsSuccess) {
                throw new ApplicationException(await httpResponseWrapper.GetBody());
            }
            
            return httpResponseWrapper.Response;
        }

        public async Task<Person> GetPersonById(int id) {
            return await _http.GetResponse<Person>($"{baseURL}/{id}");
        }

        public async Task CreatePerson(Person person) {
            var httpResponseWrapper = await _http.Post(baseURL, person);

            if (!httpResponseWrapper.IsSuccess) { 
                throw new ApplicationException(await httpResponseWrapper.GetBody());
            }
        }

        public async Task UpdatePerson(Person person) {
            var httpResponseWrapper = await _http.Put(baseURL, person);

            if (!httpResponseWrapper.IsSuccess) {
                throw new ApplicationException(await httpResponseWrapper.GetBody());
            }
        }

        public async Task DeletePerson(int Id) {
            var httpResponseWrapper = await _http.Delete($"{baseURL}/{Id}");

            if (!httpResponseWrapper.IsSuccess) {
                throw new ApplicationException(await httpResponseWrapper.GetBody());
            }
        }
    }
}