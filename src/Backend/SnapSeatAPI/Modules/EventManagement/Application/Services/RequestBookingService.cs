using EventManagement.Application.DTOs.Booking;
using EventManagement.Application.Interfaces.IServices;
using Shared.Domain.Models;

namespace EventManagement.Application.Interfaces.Services
{
    public class RequestBookingService : IRequestBookingService
    {
        private readonly IBookingRequestProducer _producer;

        public RequestBookingService(IBookingRequestProducer producer)
        {
            _producer = producer;
        }

        public async Task<Result<string>> RequestAsync(CurrentUser currentUser
            , BookingDTO dto)
        {
            var bookingMessage = new BookingRequest(currentUser, dto.TicketTypeId
                , dto.BookingTime, dto.Seats);


            await _producer.Produce(bookingMessage);

            return Result<string>.Success("We have received your booking request and It's under processing now");
        }
    }
}
