using AncientCities.Domain.Aggregates.CityAggregate;
using Microsoft.EntityFrameworkCore;
using CityType = AncientCities.Domain.Aggregates.CityTypeAggregate.CityType;

namespace AncientCities.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<CityType> Types { get; set; }
        public DbSet<CityImage> CityImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CityType>().HasData(
                new CityType(1, "Capital"),
                new CityType(2, "Regional capital"),
                new CityType(3, "Regular city"),
                new CityType(4, "Trade hub"),
                new CityType(5, "Port"),
                new CityType(6, "Town"),
                new CityType(7, "Village"),
                new CityType(8, "Hamlet")
            );

            modelBuilder.Entity<City>().HasData(
               new City(1, "Rome", "Roman Empire (after Republic, Kingdom)", 450000, new DateTime(753, 04, 21), "BC" , null, null, "Greatest city of its time", 1)
            );
        }
    }
}
