using EventManagement.Application.Interfaces.IRepos;
using EventManagement.Application.Interfaces.IServices;
using EventManagement.Application.Interfaces.Services;
using EventManagement.Application.Services;
using EventManagement.Infrastructure.Messaging;
using EventManagement.Infrastructure.Persistence;
using EventManagement.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EventManagement.DependencyInjection
{
    public static class EventModule
    {
        public static IServiceCollection AddEventModule(this IServiceCollection services,
        IConfiguration configuration)
        {
            services.AddDbContext<EventDBContext>(opt =>
        opt.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));


            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IEventCategoryService, EventCategoryService>();
            services.AddScoped<IEventTagService, EventTagService>();
            services.AddScoped<ITicketTypeService, TicketTypeService>();
            services.AddScoped<IRequestBookingService, RequestBookingService>();
            services.AddScoped<IConfirmBookingService, ConfirmBookingService>();
            services.AddScoped<IBookingRequestProducer, BookingRequestProducer>();


            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IEventCategoryRepository, EventCategoryRepository>();
            services.AddScoped<IEventTagRepository, EventTagRepository>();
            services.AddScoped<ITicketTypeRepository, TicketTypeRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();


            return services;
        }
    }
}
