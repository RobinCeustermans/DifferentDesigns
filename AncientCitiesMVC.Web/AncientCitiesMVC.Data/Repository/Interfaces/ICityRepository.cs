using AncientCitiesMVC.Models;

namespace AncientCitiesMVC.Data.Repository.Interfaces
{
    public interface ICityRepository : IRepository<City>
    {
        void Update(City city);
    }
}
