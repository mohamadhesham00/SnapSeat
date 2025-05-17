using EventManagement.Application.DTOs.EventCategory;
using EventManagement.Domain.Entities;

namespace EventManagement.Common.Mapping
{
    public static class EventCategoryMappingExtensions
    {
        public static GetEventCategoryDTO ToGetDto(this EventCategory eventCategory)
        {
            return new GetEventCategoryDTO(eventCategory.Id, eventCategory.Name);
        }

        public static List<GetEventCategoryDTO> ToGetDtoList(this IEnumerable<EventCategory> eventCategories)
        {
            return eventCategories.Select(u => u.ToGetDto()).ToList();
        }

        public static EventCategory ToEntity(this EventCategoryDTO dto)
        {
            return new EventCategory(dto.Name);
        }
    }
}
