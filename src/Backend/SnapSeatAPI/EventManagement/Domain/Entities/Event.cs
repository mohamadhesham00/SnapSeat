using Shared.Domain.Models;

namespace EventManagement.Domain.Entities
{
    public class Event : BaseEntity
    {

        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
        public Guid EventCategoryId { get; set; }
        public EventCategory EventCategory { get; set; }
        public List<EventTag> Tags { get; set; } = new();
        public List<TicketType> TicketTypes { get; set; } = new();

        public bool IsDeleted { get; set; }

        // For EFCore
        private Event()
        {

        }
        public Event(string name, DateTime startTime, DateTime endTime
            , string location, string description
            , Guid eventCategoryId)
        {
            Name = name;
            StartTime = startTime;
            EndTime = endTime;
            Location = location;
            Description = description;
            EventCategoryId = eventCategoryId;
        }



    }
}
