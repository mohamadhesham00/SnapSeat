using EventManagement.Application.DTOs.EventCategory;
using Shared.Domain.Models;

namespace EventManagement.Application.Interfaces.IServices
{
    public interface IEventCategoryService
    {
        public Task<Result<IReadOnlyList<GetEventCategoryDTO>>> BrowseAsync(CurrentUser currentUser, CancellationToken cancellationToken);
        public Task<Result<GetEventCategoryDTO>> CreateAsync(CurrentUser currentUser, EventCategoryDTO dto, CancellationToken cancellationToken = default);

        public Task<Result<GetEventCategoryDTO>> GetAsync(CurrentUser currentUser, Guid id, CancellationToken cancellationToken = default);

        public Task<Result<GetEventCategoryDTO>> UpdateAsync(CurrentUser currentUser, Guid id, EventCategoryDTO dto, CancellationToken cancellationToken = default);

        public Task<Result<bool>> DeleteAsync(CurrentUser currentUser, Guid id, CancellationToken cancellationToken = default);
    }
}
