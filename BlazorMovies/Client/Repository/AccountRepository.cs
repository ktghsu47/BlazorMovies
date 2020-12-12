using System;
using System.Threading.Tasks;
using BlazorMovies.Client.Helpers;
using BlazorMovies.Shared.DTOs;

namespace BlazorMovies.Client.Repository {
	public class AccountRepository : IAccountRepository {
        private readonly IHttpService _http;
        private readonly string baseURL = "api/accounts";

        public AccountRepository(IHttpService httpService) {
            _http = httpService;
        }

        public async Task<TokenDTO> Register(UserInfoDTO userInfoDTO) {
            var httpResponseWrapper = await _http.Post<UserInfoDTO, TokenDTO>($"{baseURL}/register", userInfoDTO);

            if (!httpResponseWrapper.IsSuccess) {
                throw new ApplicationException(await httpResponseWrapper.GetBody());
            }

            return httpResponseWrapper.Response;
        }

        public async Task<TokenDTO> Login(UserInfoDTO userInfoDTO) {
            var httpResponseWrapper = await _http.Post<UserInfoDTO, TokenDTO>($"{baseURL}/login", userInfoDTO);

            if (!httpResponseWrapper.IsSuccess) {
                throw new ApplicationException(await httpResponseWrapper.GetBody());
            }

            return httpResponseWrapper.Response;
        }

        public async Task<TokenDTO> RenewToken() {
            var httpResponseWrapper = await _http.Get<TokenDTO>($"{baseURL}/RenewToken");

            if (!httpResponseWrapper.IsSuccess) {
                throw new ApplicationException(await httpResponseWrapper.GetBody());
            }

            return httpResponseWrapper.Response;
        }
    }
}