using AncientCities.Domain.Entities;
using AncientCities.Domain.Interfaces.Data;
using AutoMapper;
using System.Linq.Expressions;

namespace AncientCities.Application.AncientCity.Queries
{
    public class GetAllCitiesQuery
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllCitiesQuery(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<CityDto>> ExecuteAsync(Expression<Func<City, bool>>? filter = null, string? includeProperties = null)
        {
            var cities = await _unitOfWork.CityRepository.GetAll(filter, includeProperties);
            return _mapper.Map<List<CityDto>>(cities);
        }
    }
}
