using GameStore.Api.Models;
using GameStore.Api.Entities;
using Microsoft.AspNetCore.Mvc;
using GameStore.Api.Services;
using Microsoft.AspNetCore.Authorization;
using GameStore.Api.Models.Auth;

namespace GameStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        public static User user = new();

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(RegisterModel request)
        {
            var user = await authService.RegisterAsync(request);
            if (user is null) return BadRequest("Username already exist.");

            return Ok(user);
        }


        [HttpPost("login")]
        public async Task<ActionResult<TokenResponseDto>> Login(LoginModel request)
        {
            var res = await authService.LoginAsync(request);
            if (res is null) return BadRequest("Invalid username or password");
            return Ok(res);
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<TokenResponseDto>> RefreshToken(RefreshTokenRequestDto request)
        {
            var result = await authService.RefreshTokenAsync(request);
            if (result is null || result.AccessToken is null || result.RefreshToken is null) return Unauthorized("Invalid refresh token");

            return Ok(result);
        }

        [Authorize]
        [HttpGet]
        public IActionResult AuthenticatedOnlyEndpoint()
        {
            return Ok("You are AUTHENTICATED!");
        }

        [Authorize(Roles = "Admin")] // Roles = "Admin,Meneger")
        [HttpGet("admin-only")]
        public IActionResult AdminOnlyEndpoint()
        {
            return Ok("You are an ADMIN!");
        }
    }
}
