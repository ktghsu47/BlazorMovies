using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorMovies.Client.Helpers {
	public class HttpResponseWrapper<T> {
        public HttpResponseWrapper(T response, bool isSuccess, HttpResponseMessage httpResponseMessage) {
            Response = response;
            IsSuccess = isSuccess;
            HttpResponseMessage = httpResponseMessage;
        }

        public T Response { get; set; }
        public bool IsSuccess { get; set; }
        public HttpResponseMessage HttpResponseMessage { get; set; }

        public async Task<string> GetBody() {
            return await HttpResponseMessage.Content.ReadAsStringAsync();
        }
    }
}