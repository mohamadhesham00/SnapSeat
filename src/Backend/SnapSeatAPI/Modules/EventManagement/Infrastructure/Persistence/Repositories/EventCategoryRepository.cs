﻿using EventManagement.Application.Interfaces.IRepos;
using EventManagement.Domain.Entities;
using Shared.Infrastructure;

namespace EventManagement.Infrastructure.Persistence.Repositories
{
    public class EventCategoryRepository : Repository<EventCategory, EventDBContext>, IEventCategoryRepository
    {

        public EventCategoryRepository(EventDBContext db) : base(db) { }


    }
}
