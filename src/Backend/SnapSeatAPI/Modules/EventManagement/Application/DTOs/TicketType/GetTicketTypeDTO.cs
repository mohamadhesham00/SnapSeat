namespace EventManagement.Application.DTOs.TicketType
{
    public record GetTicketTypeDTO(Guid Id, string Name, int Capacity, decimal Price, Guid EventId);

}
