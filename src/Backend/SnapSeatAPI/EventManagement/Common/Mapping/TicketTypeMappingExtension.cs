using EventManagement.Application.DTOs.TicketType;
using EventManagement.Domain.Entities;

namespace EventManagement.Common.Mapping
{
    public static class TicketTypeMappingExtension
    {
        public static GetTicketTypeDTO ToGetDto(this TicketType ticketType)
        {
            return new GetTicketTypeDTO(ticketType.Id, ticketType.Name
                , ticketType.Capacity, ticketType.Price, ticketType.EventId);
        }

        public static List<GetTicketTypeDTO> ToGetDtoList(this IEnumerable<TicketType> ticketTypes)
        {
            return ticketTypes.Select(u => u.ToGetDto()).ToList();
        }

        public static TicketType ToEntity(this TicketTypeDTO dto)
        {
            return new TicketType(dto.Name, dto.Capacity, dto.Price, dto.EventId);
        }

        public static TicketType ToEntity(this PutTicketTypeDTO dto, TicketType entity)
        {
            var ticketType = new TicketType(
                dto.Name ?? entity.Name
                , dto.Capacity ?? entity.Capacity
                , dto.Price ?? entity.Price
                , entity.EventId
                );

            return ticketType;
        }
    }
}
