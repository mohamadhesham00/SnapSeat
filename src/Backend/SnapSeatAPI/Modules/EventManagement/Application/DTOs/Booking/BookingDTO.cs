using System.ComponentModel.DataAnnotations;

namespace EventManagement.Application.DTOs.Booking
{
    public record BookingDTO
    {
        [Required]
        public Guid TicketTypeId { get; set; }
        [Required]
        public DateTime BookingTime { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "You have to enter at least one seat")]
        public int Seats { get; set; }
        public BookingDTO(Guid ticketTypeId, DateTime bookingTime, int seats)
        {
            TicketTypeId = ticketTypeId;
            BookingTime = bookingTime;
            Seats = seats;
        }
    }
}
