namespace Shared.Domain.Models
{
    public record PaginationRequest
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
