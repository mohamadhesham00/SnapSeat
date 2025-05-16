using EventManagement.Application.DTOs.EventCategory;
using EventManagement.Application.DTOs.EventTag;

namespace EventManagement.Application.DTOs.Event
{
    public record GetEventDTO
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
        public GetEventCategoryDTO EventCategory { get; set; }
        public List<GetEventTagDTO> Tags { get; set; }
        public GetEventDTO(Guid id, string name
            , DateTime startTime, DateTime endTime
            , string location, string description
            , string? imageUrl, GetEventCategoryDTO eventCategory
            , List<GetEventTagDTO> tags)
        {
            Id = id;
            Name = name;
            StartTime = startTime;
            EndTime = endTime;
            Location = location;
            Description = description;
            ImageUrl = imageUrl;
            EventCategory = eventCategory;
            Tags = tags;
        }
    }
}
