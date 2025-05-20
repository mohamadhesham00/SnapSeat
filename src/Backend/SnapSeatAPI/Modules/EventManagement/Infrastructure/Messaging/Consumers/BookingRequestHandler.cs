using EventManagement.Application.DTOs.Booking;
using EventManagement.Application.Interfaces.IServices;
using KafkaFlow;
using Microsoft.Extensions.DependencyInjection;
using Shared.Domain.Models;

namespace EventManagement.Infrastructure.Messaging.Consumers
{
    public class BookingRequestHandler : IMessageHandler<BookingRequest>
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public BookingRequestHandler(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public async Task Handle(IMessageContext context, BookingRequest message)
        {
            using var scope = _scopeFactory.CreateScope();

            var confirmBookingService = scope.ServiceProvider.GetRequiredService<IConfirmBookingService>();

            var bookingDto = new BookingDTO(message.TicketTypeId, message.BookingTime, message.Seats);

            await confirmBookingService.CreateBookingAsync(message.CurrentUser, bookingDto);
        }
    }
}
