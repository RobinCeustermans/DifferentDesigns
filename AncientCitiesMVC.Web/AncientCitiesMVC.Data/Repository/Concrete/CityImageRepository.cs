using AncientCitiesMVC.Data.DbApplicationContext;
using AncientCitiesMVC.Data.Repository.Interfaces;
using AncientCitiesMVC.Models;

namespace AncientCitiesMVC.Data.Repository.Concrete
{
    public class CityImageRepository : Repository<CityImage>, ICityImageRepository
    {
        ApplicationDbContext _context;
        public CityImageRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(CityImage cityImage)
        {
            _context.CityImages.Update(cityImage);
        }
    }
}
