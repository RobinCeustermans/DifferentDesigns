using AncientCities.Domain.Aggregates.CityAggregate;
using AncientCities.Domain.Aggregates.CityAggregate.Repositories;

namespace AncientCities.Infrastructure.Persistence.Repositories
{
   public class CityRepository : Repository<City>, ICityRepository
   {
        private readonly ApplicationDbContext _context;

        public CityRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
   }
}
