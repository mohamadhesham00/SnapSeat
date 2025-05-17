using EventManagement.Application.Interfaces.IRepos;
using EventManagement.Domain.Entities;
using Shared.Infrastructure;

namespace EventManagement.Infrastructure.Persistence.Repositories
{
    public class TicketTypeRepository : Repository<TicketType, EventDBContext>, ITicketTypeRepository
    {
        public TicketTypeRepository(EventDBContext db) : base(db) { }

        public IQueryable<TicketType> GetAllTypeForEvent(Guid eventId, CancellationToken cancellationToken)
        {
            return _dbSet.Where(x => x.EventId == eventId);
        }
    }
}
