using Auth.Application.DTOs;
using Shared.Domain.Models;

namespace Auth.Application.Interfaces
{
    public interface IAuthService
    {
        public Task<Result<AuthResponse>> RegisterAsync(RegisterRequest request);
        public Task<Result<AuthResponse>> LoginAsync(LoginRequest request);
        public Task<Result<AuthResponse>> RefreshAsync(RefreshTokenRequest request);
    }
}
