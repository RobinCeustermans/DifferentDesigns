using AncientCities.Application.DTOs;
using AncientCities.Domain.Common.Interfaces;
using AutoMapper;
using System.Linq.Expressions;

namespace AncientCities.Application.UseCases.City.Queries
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

        public async Task<List<CityDto>> ExecuteAsync(Expression<Func<Domain.Aggregates.CityAggregate.City, bool>>? filter = null, string? includeProperties = null)
        {
            var cities = await _unitOfWork.CityRepository.GetAllAsync(filter, includeProperties);
            return _mapper.Map<List<CityDto>>(cities);
        }
    }
}
