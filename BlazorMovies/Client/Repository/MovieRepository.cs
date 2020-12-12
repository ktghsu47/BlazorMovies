using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorMovies.Client.Helpers;
using BlazorMovies.Shared.DTOs;
using BlazorMovies.Shared.Entities;

namespace BlazorMovies.Client.Repository {
	public class MovieRepository : IMovieRepository {
        private readonly IHttpService _http;
        private readonly string baseURL = "api/movies";

        public MovieRepository(IHttpService httpService) {
            _http = httpService;
        }

        public async Task<IndexPageDTO> GetIndexPageDTO() {
            //return await _http.GetResponse<IndexPageDTO>(baseURL, false);
            return await _http.GetResponse<IndexPageDTO>(baseURL);
        }

        public async Task<MovieUpdateDTO> GetMovieForUpdate(int id) {
            return await _http.GetResponse<MovieUpdateDTO>($"{baseURL}/update/{id}");
        }

        public async Task<DetailsMovieDTO> GetDetailsMovieDTO(int id) {
            //return await _http.GetResponse<DetailsMovieDTO>($"{baseURL}/{id}", false);
            return await _http.GetResponse<DetailsMovieDTO>($"{baseURL}/{id}");
        }

        public async Task<PagingDTO<List<Movie>>> GetMoviesFiltered(FilterMoviesDTO filterMoviesDTO) {
            //var httpResponseWrapper = await _http.Post<FilterMoviesDTO, List<Movie>>($"{baseURL}/filter", filterMoviesDTO, false);
            var httpResponseWrapper = await _http.Post<FilterMoviesDTO, List<Movie>>($"{baseURL}/filter", filterMoviesDTO);
            var pageTotal = int.Parse(httpResponseWrapper.HttpResponseMessage.Headers.GetValues("pageTotal").FirstOrDefault());

            return new PagingDTO<List<Movie>>() {
                Response = httpResponseWrapper.Response,
                PageTotal = pageTotal
            };
        }

        public async Task<int> CreateMovie(Movie movie) {
            var httpResponseWrapper = await _http.Post<Movie, int>(baseURL, movie);

            if (!httpResponseWrapper.IsSuccess) {
                throw new ApplicationException(await httpResponseWrapper.GetBody());
            }

            return httpResponseWrapper.Response;
        }

        public async Task UpdateMovie(Movie movie) {
            var httpResponseWrapper = await _http.Put(baseURL, movie);

            if (!httpResponseWrapper.IsSuccess) {
                throw new ApplicationException(await httpResponseWrapper.GetBody());
            }
        }

        public async Task DeleteMovie(int Id) {
            var httpResponseWrapper = await _http.Delete($"{baseURL}/{Id}");

            if (!httpResponseWrapper.IsSuccess) {
                throw new ApplicationException(await httpResponseWrapper.GetBody());
            }
        }
    }
}