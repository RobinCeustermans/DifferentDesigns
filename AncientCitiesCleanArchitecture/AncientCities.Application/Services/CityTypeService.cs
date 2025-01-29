using AncientCities.Application.DTOs;
using AncientCities.Application.Interfaces;
using AncientCities.Domain.Entities;
using AncientCities.Domain.Interfaces.Data;
using AutoMapper;

namespace AncientCities.Application.Services
{
    public class CityTypeService : ICityTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CityTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<CityTypeDto>> GetAllCityTypesAsync()
        {
            var cityTypes = await _unitOfWork.CityTypeRepository.GetAll();
            return _mapper.Map<List<CityTypeDto>>(cityTypes);
        }

        public async Task<CityTypeDto?> GetCityTypeByIdAsync(int id)
        {
            var cityType = await _unitOfWork.CityTypeRepository.GetAsync(x => x.Id == id);
            return cityType == null ? null : _mapper.Map<CityTypeDto>(cityType);
        }

        public async Task UpsertCityTypeAsync(CityTypeDto cityTypeDto)
        {
            var cityType = _mapper.Map<CityType>(cityTypeDto);

            if (cityType.Id == 0)
            {
                _unitOfWork.CityTypeRepository.Add(cityType);
            }
            else
            {
                _unitOfWork.CityTypeRepository.Update(cityType);
            }

            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteCityTypeAsync(int id)
        {
            var cityType = await _unitOfWork.CityTypeRepository.GetAsync(x => x.Id == id);
            if (cityType != null)
            {
                _unitOfWork.CityTypeRepository.Remove(cityType);
                await _unitOfWork.SaveAsync();
            }
        }
    }
}
