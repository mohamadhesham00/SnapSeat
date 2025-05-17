using Shared.Domain.Models;

namespace BookingAPI.Domain.Entities
{
    public class Booking : BaseEntity
    {
        public Guid TicketTypeId { get; set; }
        public DateTime BookingTime { get; set; }
        public int Seats { get; set; }
    }
}
