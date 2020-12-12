using System.Collections.Generic;

namespace BlazorMovies.Shared.DTOs {
	public class CurrentUserDTO {
		public int UserId { get; set; }
		public string RoleName { get; set; }
		public string Email { get; set; }
		public bool IsAuthenticated { get; set; }
		public bool IsAdmin { get; set; }
		//public string FirstName { get; set; }
		//public string LastName { get; set; }
		//public Dictionary<string, string> Claims { get; set; }
	}
}