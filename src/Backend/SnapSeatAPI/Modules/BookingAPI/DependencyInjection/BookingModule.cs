using BookingAPI.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookingAPI.DependencyInjection
{
    public static class BookingModule
    {
        public static IServiceCollection AddBookingModule(this IServiceCollection services,
        IConfiguration configuration)
        {
            services.AddDbContext<BookingDBContext>(opt =>
                opt.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));


            return services;
        }
    }
}
