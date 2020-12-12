using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorMovies.Client.Helpers;
using BlazorMovies.Shared.Entities;

namespace BlazorMovies.Client.Repository {
	public class GenreRepository : IGenreRepository {
        private readonly IHttpService _http;
        private readonly string baseURL = "api/genres";

        public GenreRepository(IHttpService httpService) {
            _http = httpService;
        }

        public async Task<List<Genre>> GetGenres() {
            //var httpResponseWrapper = await _http.Get<List<Genre>>(baseURL, false);
            var httpResponseWrapper = await _http.Get<List<Genre>>(baseURL);

            if (!httpResponseWrapper.IsSuccess) {
                throw new ApplicationException(await httpResponseWrapper.GetBody());
            }

            return httpResponseWrapper.Response;
        }

        public async Task<Genre> GetGenre(int Id) {
            var httpResponseWrapper = await _http.Get<Genre>($"{baseURL}/{Id}");

            if (!httpResponseWrapper.IsSuccess) {
                throw new ApplicationException(await httpResponseWrapper.GetBody());
            }

            return httpResponseWrapper.Response;
        }

        public async Task CreateGenre(Genre genre) {
            var httpResponseWrapper = await _http.Post(baseURL, genre);

            if (!httpResponseWrapper.IsSuccess) {
                throw new ApplicationException(await httpResponseWrapper.GetBody());
            }
        }

        public async Task UpdateGenre(Genre genre) {
            var httpResponseWrapper = await _http.Put(baseURL, genre);

            if (!httpResponseWrapper.IsSuccess) {
                throw new ApplicationException(await httpResponseWrapper.GetBody());
            }
        }

        public async Task DeleteGenre(int Id) {
            var httpResponseWrapper = await _http.Delete($"{baseURL}/{Id}");

            if (!httpResponseWrapper.IsSuccess) {
                throw new ApplicationException(await httpResponseWrapper.GetBody());
            }
        }
    }
}