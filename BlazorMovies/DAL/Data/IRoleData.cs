using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorMovies.Shared.Entities;

namespace BlazorMovies.DAL.Data {
	public interface IRoleData {
		Task<List<Role>> GetRoles();
	}
}
