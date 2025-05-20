using API.Configs;
using Auth.DependencyInjection;
using EventManagement.DependencyInjection;
using KafkaFlow;
using Shared.DependencyInjection;
using Shared.Infrastructure.Middleware;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
builder.Services
    .ConfigureKafka(builder.Configuration)
    .AddSharedModule(builder.Configuration)
    .AddAuthModule(builder.Configuration)
    .AddEventModule(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.ConfigureSwagger();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseMiddleware<CurrentUserMiddleware>();
app.UseAuthorization();

app.MapControllers();
await app.Services.CreateKafkaBus().StartAsync();

app.Run();
