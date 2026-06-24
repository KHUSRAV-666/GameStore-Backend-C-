using GameStore.Api.Entities;
using GameStore.Api.Models;
using GameStore.Api.Models.Auth;

namespace GameStore.Api.Services
{
    public interface IAuthService
    {
        Task<User?> RegisterAsync(RegisterModel request);
        Task<TokenResponseDto?> LoginAsync(LoginModel request);
        Task<TokenResponseDto?> RefreshTokenAsync(RefreshTokenRequestDto request);
    }
}