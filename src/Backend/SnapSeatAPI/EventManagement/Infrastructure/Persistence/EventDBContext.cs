using EventManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventManagement.Infrastructure.Persistence
{
    public class EventDBContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<EventCategory> EventCategories { get; set; }
        public DbSet<EventTag> EventTags { get; set; }
        public DbSet<TicketType> TicketTypes { get; set; }
        public EventDBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Event");
            modelBuilder.Entity<Event>().HasQueryFilter(e => !e.IsDeleted);
            base.OnModelCreating(modelBuilder);

        }
    }
}
