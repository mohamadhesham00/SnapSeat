namespace EventManagement.Application.DTOs.TicketType
{
    public record TicketTypeDTO(string Name, int Capacity, decimal Price, Guid EventId);
}
