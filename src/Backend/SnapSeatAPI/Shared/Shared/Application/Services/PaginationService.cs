using Microsoft.EntityFrameworkCore;
using Shared.Domain.Models;

namespace Shared.Application.Services
{
    public static class PaginationService
    {
        public static async Task<Pagination<TResult>> GetPaginationAsync<TEntity, TResult>(
            this IQueryable<TEntity> query,
            PaginationRequest paginationRequest,
            Func<List<TEntity>, List<TResult>> mapper,
            CancellationToken cancellationToken = default)
            where TEntity : class
        {
            var pageSize = paginationRequest.PageSize == 0 ? 10 : paginationRequest.PageSize;
            var page = paginationRequest.Page == 0 ? 1 : paginationRequest.Page;

            var totalItems = query.Count();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            var skip = (page - 1) * pageSize;
            var data = query.Skip(skip).Take(pageSize);
            var mapped = mapper(await data.ToListAsync());

            return new Pagination<TResult>
            {
                TotalItems = totalItems,
                PageSize = pageSize,
                CurrentPage = page,
                TotalPages = totalPages,
                Data = mapped
            };
        }
    }
}
