using AncientCitiesVSA.Features.CityType.DTOs;

namespace AncientCitiesVSA.Features.CityType.GetCityTypeById
{
    public interface IGetCityTypeByIdHandler
    {
        Task<CityTypeDTO?> ExecuteAsync(int id);
    }
}
