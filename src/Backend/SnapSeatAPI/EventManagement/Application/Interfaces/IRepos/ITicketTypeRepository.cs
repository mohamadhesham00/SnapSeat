using EventManagement.Domain.Entities;
using Shared.Application.Interfaces;

namespace EventManagement.Application.Interfaces.IRepos
{
    public interface ITicketTypeRepository : IRepository<TicketType>
    {
        public IQueryable<TicketType> GetAllTypeForEvent(Guid eventId, CancellationToken cancellationToken);
    }
}
