using System.Threading.Tasks;
using BlazorMovies.Shared.DTOs;

namespace BlazorMovies.Client.Auth {
	public interface ILoginService {
        Task<CurrentUserDTO> CurrentUserInfo();
        Task Login(TokenDTO tokenDTO);
        Task Logout();
        Task TryRenewToken();
    }
}