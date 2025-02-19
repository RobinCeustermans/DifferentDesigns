using AncientCities.Application.DTOs;
using AncientCities.Domain.Common.Interfaces;
using AutoMapper;

namespace AncientCities.Application.UseCases.CityType.Queries
{
    public class GetAllCityTypesQuery
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;


        public GetAllCityTypesQuery(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<CityTypeDto>> ExecuteAsync()
        {
            var cityTypes = await _unitOfWork.CityTypeRepository.GetAllAsync();
            return _mapper.Map<List<CityTypeDto>>(cityTypes);
        }
    }
}
