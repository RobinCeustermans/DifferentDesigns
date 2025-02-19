using AncientCities.Application.DTOs;
using AncientCities.Domain.Common.Interfaces;
using AutoMapper;

namespace AncientCities.Application.UseCases.CityType.Queries
{
    public class GetCityTypeByIdQuery
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCityTypeByIdQuery(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CityTypeDto?> ExecuteAsync(int id)
        {
            var cityType = await _unitOfWork.CityTypeRepository.GetByIdAsync(id);
            return cityType == null ? null : _mapper.Map<CityTypeDto>(cityType);
        }
    }
}
