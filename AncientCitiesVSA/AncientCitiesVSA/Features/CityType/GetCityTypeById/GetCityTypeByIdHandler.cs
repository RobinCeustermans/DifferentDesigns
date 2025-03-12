using AncientCitiesVSA.Features.CityType.DTOs;
using AutoMapper;
using Features.CityType.Repositories.Abstract;

namespace AncientCitiesVSA.Features.CityType.GetCityTypeById
{
    public class GetCityTypeByIdHandler : IGetCityTypeByIdHandler
    {
        private readonly IMapper _mapper;
        private readonly ICityTypeRepository _cityTypeRepository;


        public GetCityTypeByIdHandler(IMapper mapper, ICityTypeRepository cityTypeRepository)
        {
            _mapper = mapper;
            _cityTypeRepository = cityTypeRepository;
        }

        public async Task<CityTypeDTO?> ExecuteAsync(int id)
        {
            var cityType = await _cityTypeRepository.GetByIdAsync(id);
            return cityType == null ? null : _mapper.Map<CityTypeDTO>(cityType);
        }
    }
}
