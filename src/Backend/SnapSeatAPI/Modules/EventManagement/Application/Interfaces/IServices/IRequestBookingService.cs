using EventManagement.Application.DTOs.Booking;
using Shared.Domain.Models;

namespace EventManagement.Application.Interfaces.IServices
{
    public interface IRequestBookingService
    {
        public Task<Result<string>> RequestAsync(CurrentUser currentUser, BookingDTO dto);
    }
}
