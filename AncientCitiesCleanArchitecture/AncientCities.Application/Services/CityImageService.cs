using AncientCities.Application.DTOs;
using AncientCities.Application.Interfaces.Services;
using AncientCities.Domain.Interfaces.Data;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AncientCities.Application.Services
{
    public class CityImageService : ICityImageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CityImageService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task DeleteCityImageAsync(int id)
        {
            var cityImage = await _unitOfWork.CityImageRepository.GetAsync(x => x.Id == id);
            if (cityImage != null)
            {
                _unitOfWork.CityImageRepository.Remove(cityImage);
                await _unitOfWork.SaveAsync();
            }
        }

        public async Task<CityImageDto?> GetCityImageByIdAsync(int id)
        {
            var cityImage = await _unitOfWork.CityImageRepository.GetAsync(x => x.Id == id);
            return cityImage == null ? null : _mapper.Map<CityImageDto>(cityImage);
        }
    }
}
