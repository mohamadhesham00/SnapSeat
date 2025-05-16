using EventManagement.Application.DTOs.Event;
using EventManagement.Domain.Entities;

namespace EventManagement.Common.Mapping
{
    public static class EventMappingExtensions
    {
        public static GetEventDTO ToGetDto(this Event _event)
        {
            return new GetEventDTO(_event.Id, _event.Name
                , _event.StartTime, _event.EndTime
                , _event.Location, _event.Description
                , _event.ImageUrl
                , _event.EventCategory.ToGetDto()
                , _event.Tags.ToGetDtoList());
        }

        public static List<GetEventDTO> ToGetDtoList(this IEnumerable<Event> events)
        {
            return events.Select(u => u.ToGetDto()).ToList();
        }

        public static Event ToEntity(this EventDTO dto)
        {
            return new Event(dto.Name, dto.StartTime
                , dto.EndTime, dto.Location
                , dto.Description, dto.EventCategoryId);
        }
        public static Event ToEntity(this PutEventDTO dto, Event entity)
        {
            var _event = new Event(
                dto.Name ?? entity.Name
                , dto.StartTime ?? entity.StartTime
                , dto.EndTime ?? entity.EndTime
                , dto.Location ?? entity.Location
                , dto.Description ?? entity.Description
                , dto.EventCategoryId ?? entity.EventCategoryId
                );

            return _event;
        }
    }
}
