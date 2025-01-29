using AncientCitiesMVC.Models;

namespace AncientCitiesMVC.Data.Repository.Interfaces
{
    public interface ICityImageRepository : IRepository<CityImage>
    {
        void Update(CityImage cityImage);
    }
}
