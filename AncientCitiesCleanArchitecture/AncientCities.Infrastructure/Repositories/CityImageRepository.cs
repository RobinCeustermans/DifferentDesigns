using AncientCities.Domain.Entities;
using AncientCities.Domain.Interfaces.Repositories;
using AncientCities.Infrastructure.Data;

namespace AncientCities.Infrastructure.Repositories
{
    public class CityImageRepository : Repository<CityImage>, ICityImageRepository
    {
        ApplicationDbContext _context;
        public CityImageRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
