using AncientCities.Domain.Aggregates.CityAggregate;
using AncientCities.Domain.Aggregates.CityAggregate.Repositories;

namespace AncientCities.Infrastructure.Persistence.Repositories
{
    public class CityImageRepository : Repository<CityImage>, ICityImageRepository
    {
        private readonly ApplicationDbContext _context;

        public CityImageRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
