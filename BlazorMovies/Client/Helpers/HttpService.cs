using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorMovies.Client.Helpers {
    public class HttpService : IHttpService {
        private readonly HttpClient _http;
		private JsonSerializerOptions jsonSerializerOptions => new JsonSerializerOptions() {
            PropertyNameCaseInsensitive = true
        };

		public HttpService(HttpClient httpClient) {
            _http = httpClient;
		}

        public async Task<HttpResponseWrapper<T>> Get<T>(string url) {
            var responseHTTP = await _http.GetAsync(url);

            if (responseHTTP.IsSuccessStatusCode) {
                var response = await Deserialize<T>(responseHTTP, jsonSerializerOptions);
                return new HttpResponseWrapper<T>(response, true, responseHTTP);
            } else {
                return new HttpResponseWrapper<T>(default, false, responseHTTP);
            }
        }

        public async Task<HttpResponseWrapper<object>> Post<T>(string url, T data) {
            var jsonData = JsonSerializer.Serialize(data);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await _http.PostAsync(url, stringContent);

            return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
        }

        public async Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T data) {
            var jsonData = JsonSerializer.Serialize(data);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await _http.PostAsync(url, stringContent);

            if (response.IsSuccessStatusCode) {
                var responseDeserialized = await Deserialize<TResponse>(response, jsonSerializerOptions);
                return new HttpResponseWrapper<TResponse>(responseDeserialized, true, response);
            } else {
                return new HttpResponseWrapper<TResponse>(default, false, response);
            }
        }

        public async Task<HttpResponseWrapper<object>> Put<T>(string url, T data) {
            var dataJson = JsonSerializer.Serialize(data);
            var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
            var response = await _http.PutAsync(url, stringContent);
            return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
        }

        public async Task<HttpResponseWrapper<object>> Delete(string url) {
            var responseHTTP = await _http.DeleteAsync(url);
            return new HttpResponseWrapper<object>(null, responseHTTP.IsSuccessStatusCode, responseHTTP);
        }

		private async Task<T> Deserialize<T>(HttpResponseMessage httpResponse, JsonSerializerOptions options) {
            var responseString = await httpResponse.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(responseString, options);
        }
	}
}