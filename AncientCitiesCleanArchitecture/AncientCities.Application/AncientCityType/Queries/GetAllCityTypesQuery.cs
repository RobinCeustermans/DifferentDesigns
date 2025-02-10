using AncientCities.Domain.Interfaces.Data;
using AutoMapper;

namespace AncientCities.Application.AncientCityType.Queries
{
    public class GetAllCityTypesQuery
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllCityTypesQuery(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<CityTypeDto>> ExecuteAsync()
        {
            var cityTypes = await _unitOfWork.CityTypeRepository.GetAll();
            return _mapper.Map<List<CityTypeDto>>(cityTypes);
        }
    }
}
