using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BlazorMovies.DAL.Data;
using BlazorMovies.Server.Helpers;
using BlazorMovies.Shared.DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BlazorMovies.Server.Controllers {
	[ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    public class UsersController : ControllerBase {
        private readonly IUserData _repo;

        public UsersController(IUserData userData, IConfiguration configuration) {
            _repo = userData;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDTO>>> Get([FromQuery] PageNumberSizeDTO pageNumberSizeDTO) {
            var queryable = (await _repo.GetPeople()).AsQueryable();
            HttpContext.InsertPageTotalInHeader(queryable, pageNumberSizeDTO.PageSize);

            return queryable.Paginate(pageNumberSizeDTO).Select(
                x => new UserDTO { Email = x.Email, UserId = x.Id.ToString() }
            ).ToList();
        }

        [HttpGet("role")]
        public async Task<ActionResult<RoleDTO>> Get(int userId) {
            var role = await _repo.GetRole(userId);
            return new RoleDTO {
                Id = role.Id,
                RoleName = role.Name
            };
        }

        [HttpGet("roles")]
        public async Task<ActionResult<List<RoleDTO>>> Get() {
            return (await _repo.GetRoles()).Select(x => new RoleDTO { Id = x.Id, RoleName = x.Name }).ToList();
        }

        [HttpPost("assignRole")]
        public async Task<ActionResult> AssignRole(EditRoleDTO editRoleDTO) {
            //var claims = new List<Claim>();
            //claims.Add(new Claim(ClaimTypes.Role, editRoleDTO.RoleName));
            //var user = User;
            var identity = User.Identity as ClaimsIdentity;
            identity.AddClaim(new Claim(ClaimTypes.Role, editRoleDTO.RoleName));

            await _repo.AssignUserRole(Convert.ToInt32(editRoleDTO.UserId), editRoleDTO.RoleName);

            return NoContent();
        }

        [HttpPost("removeRole")]
        public async Task<ActionResult> RemoveRole(EditRoleDTO editRoleDTO) {
            //var user = User as ClaimsPrincipal;
            var identity = User.Identity as ClaimsIdentity;
            var claim = (
                from c in User.Claims
                where c.Value == editRoleDTO.RoleName
                select c
            ).Single();
            identity.RemoveClaim(claim);

            await _repo.RemoveUserRole(Convert.ToInt32(editRoleDTO.UserId), editRoleDTO.RoleName);

            return NoContent();
        }
    }
}