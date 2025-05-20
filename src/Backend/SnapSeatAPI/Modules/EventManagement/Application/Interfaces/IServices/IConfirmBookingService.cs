using EventManagement.Application.DTOs.Booking;
using Shared.Domain.Models;

namespace EventManagement.Application.Interfaces.IServices
{
    public interface IConfirmBookingService
    {
        public Task CreateBookingAsync(CurrentUser currentUser, BookingDTO dto);
    }
}
