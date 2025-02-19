using AncientCities.Domain.Aggregates.CityAggregate.Repositories;
using AncientCities.Domain.Aggregates.CityTypeAggregate.Repositories;

namespace AncientCities.Domain.Common.Interfaces
{
    public interface IUnitOfWork
    {
        ICityTypeRepository CityTypeRepository { get; }
        ICityRepository CityRepository { get; }
        ICityImageRepository CityImageRepository { get; }
        Task SaveAsync();
    }
}
