using EventManagement.Application.DTOs.TicketType;
using EventManagement.Application.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using Shared.API.Controllers;

namespace EventManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class TicketTypeController : BaseController
    {
        private readonly ITicketTypeService _service;

        public TicketTypeController(ITicketTypeService service)
        {
            _service = service;
        }

        [HttpGet("browse")]
        public async Task<IActionResult> BrowseAsync(Guid eventId, CancellationToken cancellationToken)
        {
            if (!CurrentUser.IsAuthenticated)
            {
                return Unauthorized();
            }
            var result = await _service.BrowseAsync(eventId, CurrentUser, cancellationToken);
            return this.HandleResult(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync(TicketTypeDTO dto, CancellationToken cancellationToken)
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
        public async Task<IActionResult> UpdateAsync(Guid id, PutTicketTypeDTO dto, CancellationToken cancellationToken)
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
