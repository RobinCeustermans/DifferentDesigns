using AncientCities.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AncientCities.Infrastructure.Data
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
                new CityType
                {
                    Id = 1,
                    Name = "Capital"
                },
                new CityType
                {
                    Id = 2,
                    Name = "Regional capital"
                },
                new CityType
                {
                    Id = 3,
                    Name = "Regular city"
                },
                new CityType
                {
                    Id = 4,
                    Name = "Trade hub"
                },
                new CityType
                {
                    Id = 5,
                    Name = "Port"
                },
                new CityType
                {
                    Id = 6,
                    Name = "Town"
                },
                new CityType
                {
                    Id = 7,
                    Name = "Village"
                },
                new CityType
                {
                    Id = 8,
                    Name = "Hamlet"
                }
            );

            modelBuilder.Entity<City>().HasData(
                new City
                {
                    Id = 1,
                    Name = "Rome",
                    Population = 450000,
                    PartOf = "Roman Empire (after Republic, Kingdom)",
                    Created = new DateTime(753, 04, 21),
                    EraCreated = "BC",
                    Defunct = null,
                    TypeId = 1,
                    Description = "Greatest city of its time"
                },
                new City
                {
                    Id = 2,
                    Name = "Novgorod",
                    Population = 40000,
                    PartOf = "Novgorod republic",
                    Created = new DateTime(859, 01, 01),
                    EraCreated = "AD",
                    Defunct = null,
                    TypeId = 4,
                    Description = "now named Veliky Novgorod, part of Russia"
                }
            );
        }
    }
}
