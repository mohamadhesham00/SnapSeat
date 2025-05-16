using EventManagement.Application.DTOs.EventTag;
using EventManagement.Domain.Entities;

namespace EventManagement.Common.Mapping
{
    public static class EventTagMappingExtensions
    {
        public static GetEventTagDTO ToGetDto(this EventTag eventTag)
        {
            return new GetEventTagDTO(eventTag.Id, eventTag.Name);
        }

        public static List<GetEventTagDTO> ToGetDtoList(this IEnumerable<EventTag> eventTags)
        {
            return eventTags.Select(u => u.ToGetDto()).ToList();
        }

        public static EventTag ToEntity(this EventTagDTO dto)
        {
            return new EventTag(dto.Name);
        }
    }
}
