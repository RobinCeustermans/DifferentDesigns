using AncientCities.Domain.Aggregates.CityAggregate.Repositories;
using AncientCities.Domain.Aggregates.CityTypeAggregate.Repositories;
using AncientCities.Domain.Common.Interfaces;
using AncientCities.Infrastructure.Persistence.Repositories;

namespace AncientCities.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public ICityRepository CityRepository { get; private set; }
        public ICityTypeRepository CityTypeRepository { get; private set; }
        public ICityImageRepository CityImageRepository { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            CityRepository = new CityRepository(_context);
            CityTypeRepository = new CityTypeRepository(_context);
            CityImageRepository = new CityImageRepository(_context);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
