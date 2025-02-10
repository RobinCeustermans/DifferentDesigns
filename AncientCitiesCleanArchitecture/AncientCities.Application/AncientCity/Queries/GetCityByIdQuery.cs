using AncientCities.Domain.Interfaces.Data;
using AutoMapper;

namespace AncientCities.Application.AncientCity.Queries
{
    public class GetCityByIdQuery
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCityByIdQuery(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CityDto?> ExecuteAsync(int id, string includeProperties)
        {
            var city = await _unitOfWork.CityRepository.GetAsync(x => x.Id == id, includeProperties: includeProperties);
            return city == null ? null : _mapper.Map<CityDto>(city);
        }
    }
}
