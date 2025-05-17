using Shared.Domain.Models;

namespace EventManagement.Domain.Entities
{
    public class EventTag : BaseEntity
    {
        public string Name { get; set; } = null!;

        public EventTag(string name)
        {
            Name = name;
        }
    }
}
