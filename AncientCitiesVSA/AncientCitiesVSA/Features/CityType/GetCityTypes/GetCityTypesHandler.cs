using AncientCitiesVSA.Features.CityType.DTOs;
using AutoMapper;
using Features.CityType.Repositories.Abstract;

namespace AncientCitiesVSA.Features.CityType.GetCityTypes
{
    public class GetCityTypesHandler : IGetCityTypesHandler
    {
        private readonly IMapper _mapper;
        private readonly ICityTypeRepository _cityTypeRepository;

        public GetCityTypesHandler(IMapper mapper, ICityTypeRepository cityTypeRepository)
        {
            _mapper = mapper;
            _cityTypeRepository = cityTypeRepository;
        }

        public async Task<List<CityTypeDTO>> ExecuteAsync()
        {
            var cityTypes = await _cityTypeRepository.GetAllAsync();
            return _mapper.Map<List<CityTypeDTO>>(cityTypes);
        }
    }
}
