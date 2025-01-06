using AncientCities.Application.DTOs;

namespace AncientCities.Application.Interfaces
{
    public interface ICityTypeService
    {
        Task<List<CityTypeDto>> GetAllCityTypesAsync();
        Task<CityTypeDto?> GetCityTypeByIdAsync(int id);
        Task UpsertCityTypeAsync(CityTypeDto cityTypeDto);
        Task DeleteCityTypeAsync(int id);
    }
}
