using AncientCities.Domain.Interfaces.Data;
using AutoMapper;

namespace AncientCities.Application.AncientCityType.Queries
{
    public class GetCityTypeByIdQuery
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCityTypeByIdQuery(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CityTypeDto?> ExecuteAsync(int id)
        {
            var cityType = await _unitOfWork.CityTypeRepository.GetAsync(x => x.Id == id);
            return cityType == null ? null : _mapper.Map<CityTypeDto>(cityType);
        }
    }
}
