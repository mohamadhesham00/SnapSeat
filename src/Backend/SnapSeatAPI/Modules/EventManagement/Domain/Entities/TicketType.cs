using Shared.Domain.Models;

namespace EventManagement.Domain.Entities
{
    public class TicketType : BaseEntity
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int SeatsBooked { get; set; } = 0;
        public int SeatsLeft => Capacity - SeatsBooked;

        public decimal Price { get; set; }

        public Guid EventId { get; set; }
        public Event Event { get; set; }
        public TicketType(string name, int capacity, decimal price, Guid eventId)
        {
            Name = name;
            Capacity = capacity;
            Price = price;
            EventId = eventId;
        }
    }
}
