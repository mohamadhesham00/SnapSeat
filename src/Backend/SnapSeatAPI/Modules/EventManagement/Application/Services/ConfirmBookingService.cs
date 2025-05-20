using EventManagement.Application.DTOs.Booking;
using EventManagement.Application.Interfaces.IRepos;
using EventManagement.Application.Interfaces.IServices;
using EventManagement.Domain.Entities;
using Shared.Application.Interfaces;
using Shared.Domain.Models;

namespace EventManagement.Application.Services
{
    public class ConfirmBookingService : IConfirmBookingService
    {
        private readonly IEmailService _emailService;
        private readonly ITicketTypeService _ticketService;
        private readonly IBookingRepository _repo;
        public ConfirmBookingService(IEmailService emailService,
            ITicketTypeService ticketService,
            IBookingRepository repo)
        {
            _ticketService = ticketService;
            _emailService = emailService;
            _ticketService = ticketService;
            _repo = repo;
        }

        public async Task CreateBookingAsync(CurrentUser currentUser, BookingDTO dto)
        {
            var result = await _ticketService.HandleBooking(currentUser, dto.TicketTypeId
                , dto.Seats);
            if (result.IsSuccess)
            {
                var booking = new Booking(dto.TicketTypeId, dto.BookingTime
                    , dto.Seats);
                await _repo.AddAsync(booking);
                await _repo.SaveChangesAsync();
                await _emailService.SendEmailAsync(currentUser.Email
                    , "Booking Confirmed"
                    , "Your booking was successful your seats have been reserved! "
                    + $"and here is your BookingId : {booking.Id}");
            }
            else
            {
                await _emailService.SendEmailAsync(currentUser.Email
                    , "Booking Update"
                    , result.Error);
            }
        }
    }
}
