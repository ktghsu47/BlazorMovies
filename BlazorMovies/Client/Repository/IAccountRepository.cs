using System.Threading.Tasks;
using BlazorMovies.Shared.DTOs;

namespace BlazorMovies.Client.Repository {
	public interface IAccountRepository {
        Task<TokenDTO> Login(UserInfoDTO userInfo);
        Task<TokenDTO> Register(UserInfoDTO userInfo);
        Task<TokenDTO> RenewToken();
    }
}