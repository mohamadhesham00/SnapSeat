using EventManagement.Domain.Entities;
using Shared.Application.Interfaces;

namespace EventManagement.Application.Interfaces.IRepos
{
    public interface IEventCategoryRepository : IRepository<EventCategory>
    {
        public Task<bool> Exists(Guid id);
    }
}
