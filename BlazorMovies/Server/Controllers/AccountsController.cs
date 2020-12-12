using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BlazorMovies.DAL.Data;
using BlazorMovies.Shared.DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BlazorMovies.Server.Controllers {
	[ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase {
        private readonly IUserData _repo;
        private readonly IConfiguration _config;

        public AccountsController(IUserData userData, IConfiguration configuration) {
            _repo = userData;
            _config = configuration;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<TokenDTO>> CreateUser(UserInfoDTO userInfoDTO) {
            var userId = await _repo.Register(userInfoDTO.Email, userInfoDTO.Password);
            var roleName = _config.GetSection("AppSettings:RoleName").Value.ToString();

            if (userId > 0) {
                return BuildToken(userId, roleName, userInfoDTO.Email);
            } else {
                return BadRequest("Username or password invalid");
            }
        }

        [HttpGet("CurrentUserInfo")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<CurrentUserDTO> CurrentUser() {
            var currentUserDTO = new CurrentUserDTO();

            return currentUserDTO;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<TokenDTO>> Login(UserInfoDTO userInfoDTO) {
            var user = await _repo.Login(userInfoDTO.Email, userInfoDTO.Password);

            if (user != null) {
                return BuildToken(user.Id, user.RoleName, user.Email);
            } else {
                return BadRequest("Invalid login attempt");
            }
        }

        [HttpGet("RenewToken")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<TokenDTO> Renew() {
			var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
			var roleName = User.FindFirst(ClaimTypes.Role).Value.ToString();
			var email = User.FindFirst(ClaimTypes.Email).Value.ToString();

			return BuildToken(userId, roleName, email);
        }

        private TokenDTO BuildToken(int userId, string roleName, string email) {
            var claims = new List<Claim>() {
                new Claim(ClaimTypes.Name, email),
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Role, roleName),
                new Claim(ClaimTypes.NameIdentifier, userId.ToString())
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expirationMinutes = int.Parse(_config.GetSection("AppSettings:ExpirationMinutes").Value);
            var expiration = DateTime.UtcNow.AddMinutes(expirationMinutes);
            var token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: expiration,
                signingCredentials: creds
            );

            return new TokenDTO {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }
    }
}