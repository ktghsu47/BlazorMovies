using System;
using System.Threading.Tasks;
using BlazorMovies.Client.Helpers;
using BlazorMovies.Shared.Entities;

namespace BlazorMovies.Client.Repository {
	public class RatingRepository : IRatingRepository {
        private readonly IHttpService _http;
        private readonly string baseURL = "api/rating";

        public RatingRepository(IHttpService httpService) {
            _http = httpService;
        }

        public async Task Vote(MovieRating movieRating) {
            var httpResponseWrapper = await _http.Post(baseURL, movieRating);

            if (!httpResponseWrapper.IsSuccess) {
                throw new ApplicationException(await httpResponseWrapper.GetBody());
            }
        }
    }
}