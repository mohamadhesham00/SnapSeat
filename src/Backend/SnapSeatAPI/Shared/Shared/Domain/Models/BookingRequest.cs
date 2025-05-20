namespace Shared.Domain.Models
{
    public class BookingRequest
    {
        public Guid TicketTypeId { get; set; }
        public DateTime BookingTime { get; set; }
        public int Seats { get; set; }
        public CurrentUser CurrentUser { get; set; }
        public BookingRequest()
        {

        }
        public BookingRequest(CurrentUser currentUser, Guid ticketTypeId, DateTime bookingTime
            , int seats)
        {
            CurrentUser = currentUser;
            TicketTypeId = ticketTypeId;
            BookingTime = bookingTime;
            Seats = seats;
        }

    }
}
