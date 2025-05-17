using EventManagement.Application.DTOs.EventCategory;
using EventManagement.Application.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using Shared.API.Controllers;

namespace EventManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class EventCategoryController : BaseController
    {
        private readonly IEventCategoryService _service;

        public EventCategoryController(IEventCategoryService service)
        {
            _service = service;
        }

        [HttpGet("browse")]
        public async Task<IActionResult> BrowseAsync(CancellationToken cancellationToken)
        {
            if (!CurrentUser.IsAuthenticated)
            {
                return Unauthorized();
            }
            var result = await _service.BrowseAsync(CurrentUser, cancellationToken);
            return this.HandleResult(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync(EventCategoryDTO dto, CancellationToken cancellationToken)
        {
            if (!CurrentUser.IsAuthenticated)
            {
                return Unauthorized();
            }
            var result = await _service.CreateAsync(CurrentUser, dto, cancellationToken);
            return this.HandleResult(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            if (!CurrentUser.IsAuthenticated)
            {
                return Unauthorized();
            }
            var result = await _service.GetAsync(CurrentUser, id, cancellationToken);
            return this.HandleResult(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(Guid id, EventCategoryDTO dto, CancellationToken cancellationToken)
        {
            if (!CurrentUser.IsAuthenticated)
            {
                return Unauthorized();
            }
            var result = await _service.UpdateAsync(CurrentUser, id, dto, cancellationToken);
            return this.HandleResult(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            if (!CurrentUser.IsAuthenticated)
            {
                return Unauthorized();
            }
            var result = await _service.DeleteAsync(CurrentUser, id, cancellationToken);
            return this.HandleResult(result);
        }
    }
}
