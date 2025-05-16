using Microsoft.AspNetCore.Http;
using Shared.Domain.Models;
using System.Security.Claims;

namespace Shared.Infrastructure.Middleware
{
    public class CurrentUserMiddleware
    {
        private readonly RequestDelegate _next;

        public CurrentUserMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var currentUser = GetCurrentUser(context);

            if (currentUser != null)
            {
                context.Items["CurrentUser"] = currentUser;
            }

            await _next(context);

            context.Items.Remove("CurrentUser");
        }

        private CurrentUser GetCurrentUser(HttpContext context)
        {
            var userId = context.User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userId == null || !Guid.TryParse(userId, out Guid userIdParsed))
            {
                return new CurrentUser(false);
            }
            var email = context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value ?? "";
            var role = context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value ?? "";

            var currentUser = new CurrentUser(
                userIdParsed,
                email,
                role,
                true);

            return currentUser;
        }
    }
}
