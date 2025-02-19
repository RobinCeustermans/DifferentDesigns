using AncientCities.Domain.Aggregates.CityTypeAggregate;
using AncientCities.Domain.Aggregates.CityTypeAggregate.Repositories;

namespace AncientCities.Infrastructure.Persistence.Repositories
{
    public class CityTypeRepository : Repository<CityType>, ICityTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public CityTypeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
