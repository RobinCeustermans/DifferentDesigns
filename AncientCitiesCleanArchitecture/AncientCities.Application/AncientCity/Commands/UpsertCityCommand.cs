using AncientCities.Domain.Entities;
using AncientCities.Domain.Interfaces.Data;
using AutoMapper;

namespace AncientCities.Application.AncientCity.Commands
{
    public class UpsertCityCommand
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpsertCityCommand(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task ExecuteAsync(CityDto cityDto)
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
