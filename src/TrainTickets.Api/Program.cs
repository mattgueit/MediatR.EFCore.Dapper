using Microsoft.EntityFrameworkCore;
using TrainTickets.Core;
using TrainTickets.Core.Domain.Journeys;
using TrainTickets.Core.Domain.Passengers;
using TrainTickets.Core.Domain.Tickets;
using TrainTickets.Core.Domain.Trains;
using TrainTickets.Core.Storage.Database;
using TrainTickets.Infrastructure.Domain.Journeys;
using TrainTickets.Infrastructure.Domain.Passengers;
using TrainTickets.Infrastructure.Domain.Tickets;
using TrainTickets.Infrastructure.Domain.Trains;
using TrainTickets.Infrastructure.Storage.Database;
using TrainTickets.Infrastructure.Storage.Database.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(
        typeof(Program).Assembly,
        typeof(CoreAssemblyMarker).Assembly,
        typeof(InfrastructureAssemblyMarker).Assembly
    );
});

// Database
builder.Services.AddDbContext<AppDbContext>(optionsBuilder =>
{
    optionsBuilder.UseNpgsql(
        builder.Configuration["DbConnectionString"]!, 
        b => b.MigrationsAssembly("TrainTickets.Api")
    );
});

builder.Services.AddSingleton<IDbConnectionFactory>(_ =>
{
    return new NpgsqlDbConnectionFactory(builder.Configuration["DbConnectionString"]!);
});


// Services
builder.Services.AddScoped<IJourneyRepository, JourneyRepository>();
builder.Services.AddScoped<IPassengerRepository, PassengersRepository>();
builder.Services.AddScoped<ITicketsRepository, TicketsRepository>();
builder.Services.AddScoped<ITrainsRepository, TrainsRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
