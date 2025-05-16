using EventManagement.Application.Interfaces.IRepos;
using EventManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Shared.Infrastructure;

namespace EventManagement.Infrastructure.Persistence.Repositories
{
    public class EventCategoryRepository : Repository<EventCategory, EventDBContext>, IEventCategoryRepository
    {

        public EventCategoryRepository(EventDBContext db) : base(db) { }

        public async Task<bool> Exists(Guid id)
        {
            return await _dbSet.AnyAsync(ec => ec.Id == id);
        }

    }
}
