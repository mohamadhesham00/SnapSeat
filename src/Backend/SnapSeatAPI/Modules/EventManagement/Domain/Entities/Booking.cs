using Shared.Domain.Models;

namespace EventManagement.Domain.Entities
{
    public class Booking : BaseEntity
    {
        public Guid TicketTypeId { get; set; }
        public DateTime BookingTime { get; set; }
        public int Seats { get; set; }
        public Booking(Guid ticketTypeId, DateTime bookingTime, int seats)
        {
            TicketTypeId = ticketTypeId;
            BookingTime = bookingTime;
            Seats = seats;
        }

    }
}
