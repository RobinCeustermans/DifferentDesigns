using AncientCitiesMVC.Data.DbApplicationContext;
using AncientCitiesMVC.Data.Repository.Interfaces;

namespace AncientCitiesMVC.Data.Repository.Concrete
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
    }
}
