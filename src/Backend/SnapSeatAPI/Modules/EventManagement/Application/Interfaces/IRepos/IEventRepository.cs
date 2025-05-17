using EventManagement.Domain.Entities;
using Shared.Application.Interfaces;

namespace EventManagement.Application.Interfaces.IRepos
{
    public interface IEventRepository : IRepository<Event>
    {
        public Task<bool> Exists(Guid id);
    }
}
