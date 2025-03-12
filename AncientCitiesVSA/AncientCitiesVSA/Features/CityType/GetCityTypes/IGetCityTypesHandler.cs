using AncientCitiesVSA.Features.CityType.DTOs;

namespace AncientCitiesVSA.Features.CityType.GetCityTypes
{
    public interface IGetCityTypesHandler
    {
        Task<List<CityTypeDTO>> ExecuteAsync();
    }
}
