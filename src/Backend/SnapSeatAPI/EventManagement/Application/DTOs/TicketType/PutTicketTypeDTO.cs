namespace EventManagement.Application.DTOs.TicketType
{
    public record PutTicketTypeDTO(string? Name, int? Capacity, decimal? Price);
}
