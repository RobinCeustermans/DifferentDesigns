using AncientCitiesVSA.Features.CityType.DTOs;

namespace AncientCitiesVSA.Features.CityType.UpsertCityType
{
    public interface IUpsertCityTypeHandler
    {
        Task ExecuteAsync(CityTypeDTO cityTypeDto);
    }
}
