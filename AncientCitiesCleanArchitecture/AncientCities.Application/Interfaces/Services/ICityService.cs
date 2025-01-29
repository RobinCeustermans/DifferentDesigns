using AncientCities.Application.DTOs;
using AncientCities.Domain.Entities;
using System.Linq.Expressions;

namespace AncientCities.Application.Interfaces.Services
{
    public interface ICityService
    {
        Task<List<CityDto>> GetAllCitiesAsync(Expression<Func<City, bool>>? filter = null, string? includeProperties = null);
        Task<CityDto?> GetCityByIdAsync(int id, string? includeProperties = null, bool tracked = false);
        Task UpsertCityAsync(CityDto cityDto);
        Task DeleteCityAsync(int id);
    }

}
