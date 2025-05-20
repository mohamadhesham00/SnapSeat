using EventManagement.Application.Interfaces.IRepos;
using EventManagement.Domain.Entities;
using Shared.Infrastructure;

namespace EventManagement.Infrastructure.Persistence.Repositories
{
    public class BookingRepository : Repository<Booking, EventDBContext>
        , IBookingRepository
    {
        public BookingRepository(EventDBContext db) : base(db)
        {
        }
    }
}
