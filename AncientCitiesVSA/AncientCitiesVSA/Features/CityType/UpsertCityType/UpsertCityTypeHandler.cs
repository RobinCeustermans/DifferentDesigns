using AncientCitiesVSA.Features.CityType.DTOs;
using AutoMapper;
using Features.CityType.Repositories.Abstract;

namespace AncientCitiesVSA.Features.CityType.UpsertCityType
{
    public class UpsertCityTypeHandler : IUpsertCityTypeHandler
    {
        private readonly IMapper _mapper;
        private readonly ICityTypeRepository _cityTypeRepository;

        public UpsertCityTypeHandler(IMapper mapper, ICityTypeRepository cityTypeRepository)
        {
            _mapper = mapper;
            _cityTypeRepository = cityTypeRepository;
        }

        public async Task ExecuteAsync(CityTypeDTO cityTypeDto)
        {
            var cityType = _mapper.Map<DomainModels.CityType>(cityTypeDto);

            if (cityTypeDto.Id == 0)
                await _cityTypeRepository.AddAsync(cityType);
            else
                await _cityTypeRepository.UpdateAsync(cityType);
        }
    }
}
