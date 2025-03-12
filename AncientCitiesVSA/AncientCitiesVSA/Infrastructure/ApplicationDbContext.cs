using AncientCitiesVSA.Features.CityType.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace AncientCitiesVSA.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
        {
        }

        public DbSet<CityType> Types { get; set; }

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
        }
    }
}
