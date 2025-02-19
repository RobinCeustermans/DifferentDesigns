using AncientCities.Application.DTOs;
using AncientCities.Domain.Common.Interfaces;
using AutoMapper;

namespace AncientCities.Application.UseCases.CityImage.Queries
{
    public class GetCityImageByIdQuery
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCityImageByIdQuery(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CityImageDto?> ExecuteAsync(int id)
        {
            var cityImage = await _unitOfWork.CityImageRepository.GetByIdAsync(id);
            return cityImage == null ? null : _mapper.Map<CityImageDto>(cityImage);
        }
    }
}
