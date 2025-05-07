using Auth.Application.Interfaces;
using Auth.Application.Services;
using Auth.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Auth.DependencyInjection
{
    public static class AuthModule
    {
        public static IServiceCollection AddAuthModule(this IServiceCollection services,
        IConfiguration configuration)
        {
            services.AddDbContext<AuthDBContext>(opt =>
        opt.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddScoped<IRefreshTokenService, RefreshTokenService>();
            return services;
        }
    }
}
