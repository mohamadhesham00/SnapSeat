using EventManagement.Application.DTOs.Booking;
using EventManagement.Application.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using Shared.API.Controllers;

namespace EventManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : BaseController
    {
        private readonly IRequestBookingService _service;

        public BookingController(IRequestBookingService service)
        {
            _service = service;
        }

        [HttpPost("request-book")]
        public async Task<IActionResult> RequestBooking(BookingDTO dto)
        {
            if (!CurrentUser.IsAuthenticated)
            {
                return Unauthorized();
            }
            var result = await _service.RequestAsync(CurrentUser, dto);
            return this.HandleResult(result);
        }
    }
}
