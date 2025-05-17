using BookingAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookingAPI.Infrastructure.Persistence
{
    public class BookingDBContext : DbContext
    {
        public DbSet<Booking> Bookings { get; set; }
        public BookingDBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Booking");
            base.OnModelCreating(modelBuilder);
        }
    }
}
