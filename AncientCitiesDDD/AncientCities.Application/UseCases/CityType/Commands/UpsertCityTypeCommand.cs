using AncientCities.Application.DTOs;
using AncientCities.Domain.Common.Interfaces;
using AutoMapper;

namespace AncientCities.Application.UseCases.CityType.Commands
{
    public class UpsertCityTypeCommand
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpsertCityTypeCommand(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task ExecuteAsync(CityTypeDto cityTypeDto)
        {
            var cityType = _mapper.Map<Domain.Aggregates.CityTypeAggregate.CityType>(cityTypeDto);

            if (cityTypeDto.Id == 0)
            {
                _unitOfWork.CityTypeRepository.Add(cityType);
            }
            else
            {
                _unitOfWork.CityTypeRepository.Update(cityType);
            }

            await _unitOfWork.SaveAsync();
        }
    }
}
