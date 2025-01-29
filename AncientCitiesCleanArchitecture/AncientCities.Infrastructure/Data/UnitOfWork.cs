using AncientCities.Domain.Interfaces.Data;
using AncientCities.Domain.Interfaces.Repositories;
using AncientCities.Infrastructure.Repositories;

namespace AncientCities.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;

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

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
