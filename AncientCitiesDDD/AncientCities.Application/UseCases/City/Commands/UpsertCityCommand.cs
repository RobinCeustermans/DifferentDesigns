using AncientCities.Application.DTOs;
using AncientCities.Domain.Common.Interfaces;
using AutoMapper;

namespace AncientCities.Application.UseCases.City.Commands
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
            var city = _mapper.Map<Domain.Aggregates.CityAggregate.City>(cityDto);

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
