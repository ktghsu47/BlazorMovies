using System;
using System.Linq;
using System.Threading.Tasks;
using BlazorMovies.Shared.DTOs;

namespace BlazorMovies.Client.Helpers {
	public static class HttpServiceExtensions {
		//public static async Task<T> GetResponse<T>(
		//	this IHttpService httpService,
		//	string url,
		//	bool includeToken = true
		//) {
		public static async Task<T> GetResponse<T>(this IHttpService httpService, string url) {
			//var httpResponseWrapper = await httpService.Get<T>(url, includeToken);
			var httpResponseWrapper = await httpService.Get<T>(url);
            if (!httpResponseWrapper.IsSuccess) { throw new ApplicationException(await httpResponseWrapper.GetBody()); }
            
            return httpResponseWrapper.Response;
        }

		//public static async Task<PagingDTO<T>> GetPaging<T>(
		//	this IHttpService httpService,
		//	string url,
		//	PageNumberSizeDTO pageNumberSizeDTO,
		//	bool includeToken = true
		//) {
        public static async Task<PagingDTO<T>> GetPaging<T>(this IHttpService httpService, string url, PageNumberSizeDTO pageNumberSizeDTO) {
			string newURL;

			if (url.Contains("?")) {
                newURL = $"{url}&pageNumber={pageNumberSizeDTO.PageNumber}&pageSize={pageNumberSizeDTO.PageSize}";
            } else {
                newURL = $"{url}?pageNumber={pageNumberSizeDTO.PageNumber}&pageSize={pageNumberSizeDTO.PageSize}";
            }

            //var httpResponseWrapper = await httpService.Get<T>(newURL, includeToken);
            var httpResponseWrapper = await httpService.Get<T>(newURL);
            var pageTotal = int.Parse(httpResponseWrapper.HttpResponseMessage.Headers.GetValues("pageTotal").FirstOrDefault());

            return new PagingDTO<T> {
                Response = httpResponseWrapper.Response,
                PageTotal = pageTotal
            };
        }
    }
}