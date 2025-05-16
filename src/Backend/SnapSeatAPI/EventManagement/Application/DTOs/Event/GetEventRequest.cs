namespace EventManagement.Application.DTOs.Event
{
    public record GetEventRequest
    {
        public string? Name { get; set; }
        public DateTime? StartTime { get; set; }
        public string? Location { get; set; }
        public Guid? EventCategoryId { get; set; }
        public Guid? EventTagId { get; set; }
    }
}
