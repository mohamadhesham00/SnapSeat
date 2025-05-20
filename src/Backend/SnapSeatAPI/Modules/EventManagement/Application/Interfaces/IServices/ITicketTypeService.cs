using EventManagement.Application.DTOs.TicketType;
using Shared.Domain.Models;

namespace EventManagement.Application.Interfaces.IServices
{
    public interface ITicketTypeService
    {
        public Task<Result<IReadOnlyList<GetTicketTypeDTO>>> BrowseAsync(Guid eventId, CurrentUser currentUser, CancellationToken cancellationToken);
        public Task<Result<GetTicketTypeDTO>> CreateAsync(CurrentUser currentUser, TicketTypeDTO dto, CancellationToken cancellationToken = default);

        public Task<Result<GetTicketTypeDTO>> GetAsync(CurrentUser currentUser, Guid id, CancellationToken cancellationToken = default);

        public Task<Result<GetTicketTypeDTO>> UpdateAsync(CurrentUser currentUser, Guid id, PutTicketTypeDTO dto, CancellationToken cancellationToken = default);

        public Task<Result<string>> HandleBooking(CurrentUser currentUser, Guid id
            , int seats);
        public Task<Result<bool>> DeleteAsync(CurrentUser currentUser, Guid id, CancellationToken cancellationToken = default);
    }
}
