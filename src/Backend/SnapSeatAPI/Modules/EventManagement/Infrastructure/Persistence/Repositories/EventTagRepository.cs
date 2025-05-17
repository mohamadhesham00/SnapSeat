using EventManagement.Application.Interfaces.IRepos;
using EventManagement.Domain.Entities;
using Shared.Infrastructure;

namespace EventManagement.Infrastructure.Persistence.Repositories
{
    internal class EventTagRepository : Repository<EventTag, EventDBContext>, IEventTagRepository
    {
        public EventTagRepository(EventDBContext db) : base(db) { }
    }
}
