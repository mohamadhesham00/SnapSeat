using EventManagement.Application.DTOs.Event;
using Shared.Domain.Models;

namespace EventManagement.Application.Interfaces.IServices
{
    public interface IEventService
    {
        public Task<Result<Pagination<GetEventDTO>>> BrowsePaginatedAsync(CurrentUser currentUser
            , GetEventRequest request
            , PaginationRequest paginationRequest, CancellationToken cancellationToken);
        public Task<Result<GetEventDTO>> CreateAsync(CurrentUser currentUser, EventDTO dto
            , CancellationToken cancellationToken = default);

        public Task<Result<GetEventDTO>> GetAsync(CurrentUser currentUser, Guid id
            , CancellationToken cancellationToken = default);

        public Task<Result<GetEventDTO>> UpdateAsync(CurrentUser currentUser, Guid id
            , PutEventDTO putEvent, CancellationToken cancellationToken = default);

        public Task<Result<bool>> DeleteAsync(CurrentUser currentUser, Guid id
            , CancellationToken cancellationToken = default);

    }
}
