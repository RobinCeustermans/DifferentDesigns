using AncientCitiesMVC.Data.DbApplicationContext;
using AncientCitiesMVC.Data.Repository.Interfaces;
using AncientCitiesMVC.Models;

namespace AncientCitiesMVC.Data.Repository.Concrete
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        ApplicationDbContext _context;
        public CityRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(City city)
        {
            var objDb = _context.Cities.FirstOrDefault(x => x.Id == city.Id);

            if (objDb != null)
            {
                objDb.Name = city.Name;
                objDb.Description = city.Description;
                objDb.EraDefunct = city.EraDefunct;
                objDb.Defunct = city.Defunct;
                objDb.EraCreated = city.EraCreated;
                objDb.Created = city.Created;
                objDb.Population = city.Population;
                objDb.PartOf = city.PartOf;
                objDb.TypeId = city.TypeId;
                objDb.CityImages = city.CityImages;
            }
        }
    }
}
