using TrainTickets.Core.Journeys;
using TrainTickets.Core.Passengers;
using TrainTickets.Core.Tickets;
using TrainTickets.Core.Trains;
using Microsoft.EntityFrameworkCore;

namespace TrainTickets.Infrastructure.Storage.Database.EntityFramework
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Journey> Journeys { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Train> Trains { get; set; }
    }
}
