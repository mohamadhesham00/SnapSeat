using Auth.Application.DTOs;
using Auth.Application.Interfaces;
using Auth.Domain.Entities;
using Auth.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Shared.Results;

namespace Auth.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly AuthDBContext _db;
        private readonly IJwtTokenGenerator _jwt;
        private readonly IRefreshTokenService _refreshTokenService;

        public AuthService(AuthDBContext db, IJwtTokenGenerator jwt, IRefreshTokenService refreshTokenService)
        {
            _db = db;
            _jwt = jwt;
            _refreshTokenService = refreshTokenService;
        }
        public async Task<Result<AuthResponse>> RegisterAsync(RegisterRequest request)
        {
            var isEmailDuplicate = await _db.Users.AnyAsync(u => u.Email == request.Email);
            if (isEmailDuplicate)
                return Result<AuthResponse>.Failure("Email already in use", System.Net.HttpStatusCode.Conflict);

            var isUsernameDuplicate = await _db.Users.AnyAsync(u => u.Username == request.Username);
            if (isUsernameDuplicate)
                return Result<AuthResponse>.Failure("Username already in use", System.Net.HttpStatusCode.Conflict);


            var user = new User
            {
                Email = request.Email,
                Username = request.Username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password)
            };
            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();

            var authResponse = await GenerateAuthTokensAsync(user);
            return Result<AuthResponse>.Success(authResponse);
        }

        public async Task<Result<AuthResponse>> LoginAsync(LoginRequest request)
        {
            var user = await _db.Users
                .Include(u => u.RefreshTokens)
                .FirstOrDefaultAsync(u => u.Username == request.Username);

            if (user is null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
                return Result<AuthResponse>.Failure("Incorrect Username or password", System.Net.HttpStatusCode.Unauthorized);

            var authResponse = await GenerateAuthTokensAsync(user);
            return Result<AuthResponse>.Success(authResponse);
        }

        public async Task<Result<AuthResponse>> RefreshAsync(RefreshTokenRequest request)
        {
            var token = await _db.RefreshTokens.Include(t => t.User)
                .FirstOrDefaultAsync(t => t.Token == request.RefreshToken);

            if (token is null || token.IsRevoked || token.Expires < DateTime.UtcNow)
                return Result<AuthResponse>.Failure("Invalid refresh token", System.Net.HttpStatusCode.Unauthorized);

            token.IsRevoked = true;
            await _db.SaveChangesAsync();

            var authResponse = await GenerateAuthTokensAsync(token.User);
            return Result<AuthResponse>.Success(authResponse);
        }


        private async Task<AuthResponse> GenerateAuthTokensAsync(User user)
        {
            var token = _jwt.GenerateToken(user);
            var refresh = _refreshTokenService.GenerateToken();
            user.RefreshTokens.Add(refresh);
            await _db.SaveChangesAsync();

            return new AuthResponse(
                token,
                refresh.Token);
        }

    }
}
