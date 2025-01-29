using AncientCities.Domain.Interfaces.Repositories;

namespace AncientCities.Domain.Interfaces.Data
{
    public interface IUnitOfWork
    {
        ICityRepository CityRepository { get; }
        ICityTypeRepository CityTypeRepository { get; }
        ICityImageRepository CityImageRepository { get; }

        void Save();
        Task SaveAsync();
    }
}
