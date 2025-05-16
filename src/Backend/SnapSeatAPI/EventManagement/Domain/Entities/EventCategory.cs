using Shared.Domain.Models;

namespace EventManagement.Domain.Entities
{
    public class EventCategory : BaseEntity
    {
        public string Name { get; set; } = null!;

        //for EfCore
        private EventCategory() { }
        public EventCategory(string name)
        {
            Name = name;
        }
    }
}
