using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Application.Interfaces;
using Shared.Application.Services;
using Shared.Infrastructure.Messaging;



namespace Shared.DependencyInjection
{
    public static class SharedModule
    {
        public static IServiceCollection AddSharedModule(this IServiceCollection services,
        IConfiguration configuration)
        {

            services.AddScoped<IKafkaMessagePublisher, KafkaMessagePublisher>();
            services.AddScoped<IEmailService, EmailService>();


            return services;
        }
    }
}
