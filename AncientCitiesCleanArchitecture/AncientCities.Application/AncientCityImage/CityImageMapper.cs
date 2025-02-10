using AncientCities.Domain.Entities;
using AutoMapper;

namespace AncientCities.Application.AncientCityImage
{
    public class CityImageMapper : Profile
    {
        public CityImageMapper()
        {
            CreateMap<CityImage, CityImageDto>().ReverseMap();
        }
    }
}
