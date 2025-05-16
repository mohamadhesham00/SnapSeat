using Microsoft.AspNetCore.Http;
using Shared.Application.Validation;

namespace EventManagement.Application.DTOs.Event
{
    public record EventDTO
    {
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public Guid EventCategoryId { get; set; }

        [AllowedContentTypes("image/jpeg", "image/png", "image/webp")]

        public IFormFile? Image { get; set; }
    }
}
