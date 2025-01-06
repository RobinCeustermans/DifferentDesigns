using AncientCities.Domain.Entities;
using AncientCities.Domain.Interfaces.Repositories;
using AncientCities.Infrastructure.Data;

namespace AncientCities.Infrastructure.Repositories
{
    public class CityTypeRepository : Repository<CityType>, ICityTypeRepository
    {
        private ApplicationDbContext _context;

        public CityTypeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
