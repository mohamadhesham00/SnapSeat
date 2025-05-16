using Microsoft.AspNetCore.Mvc;
using Shared.Domain.Models;

namespace Shared.API.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected CurrentUser CurrentUser => HttpContext.Items["CurrentUser"] as CurrentUser;
    }
}
