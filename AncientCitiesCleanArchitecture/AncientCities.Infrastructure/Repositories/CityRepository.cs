using AncientCities.Domain.Entities;
using AncientCities.Domain.Interfaces.Repositories;
using AncientCities.Infrastructure.Data;

namespace AncientCities.Infrastructure.Repositories
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        ApplicationDbContext _context;
        public CityRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
