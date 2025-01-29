using AncientCitiesMVC.Data.DbApplicationContext;
using AncientCitiesMVC.Data.Repository.Interfaces;
using AncientCitiesMVC.Models;

namespace AncientCitiesMVC.Data.Repository.Concrete
{
    public class CityTypeRepository : Repository<CityType>, ICityTypeRepository
    {
        private ApplicationDbContext _context;

        public CityTypeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(CityType cityType)
        {
            var objDb = _context.Types.FirstOrDefault(x => x.Id == cityType.Id);

            if (objDb != null)
            {
                objDb.Name = cityType.Name;
            }
        }
    }
}
