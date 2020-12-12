using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorMovies.Shared.DTOs;

namespace BlazorMovies.Client.Repository {
	public interface IUserRepository {
        Task AssignRole(EditRoleDTO editRole);
        Task<RoleDTO> GetRoleByUserId(int id);
        Task<List<RoleDTO>> GetRoles();
        Task<PagingDTO<List<UserDTO>>> GetUsers(PageNumberSizeDTO pageNumberSizeDTO);
        Task RemoveRole(EditRoleDTO editRole);
    }
}