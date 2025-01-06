using AncientCities.Application.DTOs;

namespace AncientCities.Application.Interfaces.Services
{
    public interface ICityImageService
    {
        Task<CityImageDto?> GetCityImageByIdAsync(int id);

        Task DeleteCityImageAsync(int id);
    }
}
