using EventManagement.Application.DTOs.Event;
using EventManagement.Application.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using Shared.API.Controllers;
using Shared.Domain.Models;

namespace EventManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : BaseController
    {
        private readonly IEventService _service;

        public EventController(IEventService service)
        {
            _service = service;
        }

        [HttpGet("browse")]
        public async Task<IActionResult> BrowseAsync([FromQuery] GetEventRequest request
            , [FromQuery] PaginationRequest paginationRequest
            , CancellationToken cancellationToken)
        {
            if (!CurrentUser.IsAuthenticated)
            {
                return Unauthorized();
            }
            var result = await _service.BrowsePaginatedAsync(CurrentUser,
                request, paginationRequest, cancellationToken);
            return this.HandleResult(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromForm] EventDTO dto, CancellationToken cancellationToken)
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
        public async Task<IActionResult> UpdateAsync(Guid id, PutEventDTO dto, CancellationToken cancellationToken)
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
