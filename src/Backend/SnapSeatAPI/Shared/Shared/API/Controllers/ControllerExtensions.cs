using Microsoft.AspNetCore.Mvc;
using Shared.Domain.Models;

namespace Shared.API.Controllers
{
    public static class ControllerExtensions
    {
        public static IActionResult HandleResult<T>(this ControllerBase controller, Result<T> result)
        {
            if (!result.IsSuccess)
            {
                return controller.StatusCode((int)result.StatusCode, new { error = result.Error });
            }

            return controller.StatusCode((int)result.StatusCode, result.Value);
        }
    }
}
