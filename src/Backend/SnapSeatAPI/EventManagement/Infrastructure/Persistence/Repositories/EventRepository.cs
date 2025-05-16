using EventManagement.Application.Interfaces.IRepos;
using EventManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Shared.Infrastructure;

namespace EventManagement.Infrastructure.Persistence.Repositories
{
    public class EventRepository : Repository<Event, EventDBContext>, IEventRepository
    {
        public EventRepository(EventDBContext db) : base(db)
        {

        }

        public override IQueryable<Event> GetAllAsync()
        {
            return base.GetAllAsync()
                .Include(e => e.Tags)
                .Include(e => e.EventCategory);
        }
        public async override Task<Event?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _dbSet
                .Include(e => e.EventCategory)
                .Include(e => e.Tags)
                .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }
        public async Task<bool> Exists(Guid id)
        {
            return await _dbSet.AnyAsync(e => e.Id == id);
        }
    }
}
