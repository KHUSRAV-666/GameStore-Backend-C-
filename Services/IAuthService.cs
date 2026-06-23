using JwtAuthDotNet.Entities;
using JwtAuthDotNet.Models;

namespace GameStore.Api.Services
{
    public interface IAuthService
    {
        Task<User?> RegisterAsync(UserDto request);
        Task<string?> LoginAsync(UserDto request);
    }
}