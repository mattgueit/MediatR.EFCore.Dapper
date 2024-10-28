using Microsoft.EntityFrameworkCore;
using TrainTickets.Core.Domain.Tickets;
using TrainTickets.Core.Domain.Trains;
using TrainTickets.Core.Domain.Journeys;
using TrainTickets.Core.Domain.Passengers;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
