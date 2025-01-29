using AncientCitiesMVC.Models;

namespace AncientCitiesMVC.Data.Repository.Interfaces
{
    public interface ICityTypeRepository : IRepository<CityType>
    {
        void Update(CityType cityType);
    }
}
