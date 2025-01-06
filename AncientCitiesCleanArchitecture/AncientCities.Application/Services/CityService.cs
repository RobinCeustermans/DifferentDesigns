using AncientCities.Application.DTOs;
using AncientCities.Application.Interfaces.Services;
using AncientCities.Domain.Entities;
using AncientCities.Domain.Interfaces.Data;
using AutoMapper;
using System.Linq.Expressions;

namespace AncientCities.Application.Services
{
    public class CityService : ICityService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CityService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task DeleteCityAsync(int id)
        {
            var city = await _unitOfWork.CityRepository.GetAsync(x => x.Id == id);
            if (city != null)
            {
                _unitOfWork.CityRepository.Remove(city);
                await _unitOfWork.SaveAsync();
            }
        }

        public async Task<List<CityDto>> GetAllCitiesAsync(Expression<Func<City, bool>>? filter = null, string? includeProperties = null)
        {
            var cities = await _unitOfWork.CityRepository.GetAll(filter, includeProperties);
            return _mapper.Map<List<CityDto>>(cities);
        }

        public async Task<CityDto?> GetCityByIdAsync(int id, string? includeProperties = null, bool tracked = false)
        {
            var city = await _unitOfWork.CityRepository.GetAsync(x => x.Id == id, includeProperties, tracked);
            return city == null ? null : _mapper.Map<CityDto>(city);
        }

        public async Task UpsertCityAsync(CityDto cityDto)
        {
            var city = _mapper.Map<City>(cityDto);
            if (city.Id == 0)
            {
                _unitOfWork.CityRepository.Add(city);
            }
            else
            {
                _unitOfWork.CityRepository.Update(city);
            }

            await _unitOfWork.SaveAsync();
        }
    }
}
