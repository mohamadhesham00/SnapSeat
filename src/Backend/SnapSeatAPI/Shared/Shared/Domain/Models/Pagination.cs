namespace Shared.Domain.Models
{
    public class Pagination<T>
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }
        public bool HasPreviousPage { get { return CurrentPage > 1; } }
        public bool HasNextPage { get { return CurrentPage < TotalPages; } }
        public List<T> Data { get; set; }
    }
}
