using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorMovies.Client.Helpers;
using BlazorMovies.Shared.DTOs;

namespace BlazorMovies.Client.Repository {
	public class UserRepository : IUserRepository {
        private readonly IHttpService _http;
        private readonly string baseURL = "api/users";

        public UserRepository(IHttpService httpService) {
            _http = httpService;
        }

        public async Task<PagingDTO<List<UserDTO>>> GetUsers(PageNumberSizeDTO pageNumberSizeDTO) {
            return await _http.GetPaging<List<UserDTO>>(baseURL, pageNumberSizeDTO);
        }

        public async Task<RoleDTO> GetRoleByUserId(int id) {
            return await _http.GetResponse<RoleDTO>($"{baseURL}/role/{id}");
        }

        public async Task<List<RoleDTO>> GetRoles() {
            return await _http.GetResponse<List<RoleDTO>>($"{baseURL}/roles");
        }

        public async Task AssignRole(EditRoleDTO editRole) {
            var httpResponseWrapper = await _http.Post($"{baseURL}/assignRole", editRole);

            if (!httpResponseWrapper.IsSuccess) {
                throw new ApplicationException(await httpResponseWrapper.GetBody());
            }
        }

        public async Task RemoveRole(EditRoleDTO editRole) {
            var httpResponseWrapper = await _http.Post($"{baseURL}/removeRole", editRole);

            if (!httpResponseWrapper.IsSuccess) {
                throw new ApplicationException(await httpResponseWrapper.GetBody());
            }
        }
    }
}