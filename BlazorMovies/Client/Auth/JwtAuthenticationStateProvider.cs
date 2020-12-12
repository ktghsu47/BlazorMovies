using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using BlazorMovies.Client.Helpers;
using BlazorMovies.Client.Repository;
using BlazorMovies.Shared.DTOs;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;

namespace BlazorMovies.Client.Auth {
	public class JwtAuthenticationStateProvider : AuthenticationStateProvider, ILoginService {
        private readonly IJSRuntime _js;
        private readonly HttpClient _http;
        private readonly IAccountRepository _account;
        private readonly string TOKENKEY = "TOKENKEY";
        private readonly string EXPIRATIONTOKENKEY = "EXPIRATIONTOKENKEY";
        private AuthenticationState Anonymous => new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));

        public JwtAuthenticationStateProvider(IJSRuntime js, HttpClient httpClient, IAccountRepository repoAccount) {
            _js = js;
            _http = httpClient;
            _account = repoAccount;
        }

        public async override Task<AuthenticationState> GetAuthenticationStateAsync() {
            var tokenKey = await _js.GetLocalStorage(TOKENKEY);

            if (string.IsNullOrEmpty(tokenKey)) {
                return Anonymous;
            }

            var expirationTokenKey = await _js.GetLocalStorage(EXPIRATIONTOKENKEY);

			if (DateTime.TryParse(expirationTokenKey, out DateTime expirationTime)) {
				if (IsTokenExpired(expirationTime)) {
					await CleanUp();
					return Anonymous;
				}

				if (ShouldRenewToken(expirationTime)) {
					tokenKey = await RenewToken(tokenKey);
				}
			}

			return BuildAuthenticationState(tokenKey);
        }

        public async Task<CurrentUserDTO> CurrentUserInfo() {
            var result = await _http.GetFromJsonAsync<CurrentUserDTO>("api/auth/currentuserinfo");
            return result;
        }

        public async Task Login(TokenDTO tokenDTO) {
            await _js.SetLocalStorage(TOKENKEY, tokenDTO.Token);
            await _js.SetLocalStorage(EXPIRATIONTOKENKEY, tokenDTO.Expiration.ToString());
            var authState = BuildAuthenticationState(tokenDTO.Token);
            NotifyAuthenticationStateChanged(Task.FromResult(authState));
        }

        public async Task Logout() {
            await CleanUp();
            NotifyAuthenticationStateChanged(Task.FromResult(Anonymous));
        }

        public async Task TryRenewToken() {
            var expirationTokenKey = await _js.GetLocalStorage(EXPIRATIONTOKENKEY);

			if (DateTime.TryParse(expirationTokenKey, out DateTime expirationTime)) {
				if (IsTokenExpired(expirationTime)) {
					await Logout();
				}

				if (ShouldRenewToken(expirationTime)) {
					var tokenKey = await _js.GetLocalStorage(TOKENKEY);
					var newToken = await RenewToken(tokenKey);
					var authState = BuildAuthenticationState(newToken);
					NotifyAuthenticationStateChanged(Task.FromResult(authState));
				}
			}
		}

        private AuthenticationState BuildAuthenticationState(string token) {
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);

            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt")));
        }

        private async Task<string> RenewToken(string token) {
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            var newTokenDTO = await _account.RenewToken();
            await _js.SetLocalStorage(TOKENKEY, newTokenDTO.Token);
            await _js.SetLocalStorage(EXPIRATIONTOKENKEY, newTokenDTO.Expiration.ToString());

            return newTokenDTO.Token;
        }

        private bool ShouldRenewToken(DateTime expirationTime) {
            return expirationTime.Subtract(DateTime.UtcNow) < TimeSpan.FromMinutes(5);
        }

        private bool IsTokenExpired(DateTime expirationTime) {
            return expirationTime <= DateTime.UtcNow;
        }

        private IEnumerable<Claim> ParseClaimsFromJwt(string jwt) {
            var claims = new List<Claim>();
            var payload = jwt.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

            keyValuePairs.TryGetValue(ClaimTypes.Role, out object roles);

            if (roles != null) {
                if (roles.ToString().Trim().StartsWith("[")) {
                    var parsedRoles = JsonSerializer.Deserialize<string[]>(roles.ToString());

                    foreach (var parsedRole in parsedRoles) {
                        claims.Add(new Claim(ClaimTypes.Role, parsedRole));
                    }
                } else {
                    claims.Add(new Claim(ClaimTypes.Role, roles.ToString()));
                }

                keyValuePairs.Remove(ClaimTypes.Role);
            }

            claims.AddRange(keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString())));

            return claims;
        }

        private byte[] ParseBase64WithoutPadding(string base64) {
            switch (base64.Length % 4) {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }

            return Convert.FromBase64String(base64);
        }

        private async Task CleanUp() {
            await _js.RemoveLocalStorage(TOKENKEY);
            await _js.RemoveLocalStorage(EXPIRATIONTOKENKEY);

            _http.DefaultRequestHeaders.Authorization = null;
        }
	}
}