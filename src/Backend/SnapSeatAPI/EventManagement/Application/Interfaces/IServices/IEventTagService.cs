using EventManagement.Application.DTOs.EventTag;
using Shared.Domain.Models;

namespace EventManagement.Application.Interfaces.IServices
{
    public interface IEventTagService
    {
        public Task<Result<IReadOnlyList<GetEventTagDTO>>> BrowseAsync(CurrentUser currentUser, CancellationToken cancellationToken);
        public Task<Result<GetEventTagDTO>> CreateAsync(CurrentUser currentUser, EventTagDTO dto, CancellationToken cancellationToken = default);

        public Task<Result<GetEventTagDTO>> GetAsync(CurrentUser currentUser, Guid id, CancellationToken cancellationToken = default);

        public Task<Result<GetEventTagDTO>> UpdateAsync(CurrentUser currentUser, Guid id, EventTagDTO dto, CancellationToken cancellationToken = default);

        public Task<Result<bool>> DeleteAsync(CurrentUser currentUser, Guid id, CancellationToken cancellationToken = default);
    }
}
