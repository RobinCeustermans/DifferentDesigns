using AncientCities.Domain.Entities;
using AutoMapper;

namespace AncientCities.Application.AncientCityType
{
    public class CityTypeMapper : Profile
    {
        public CityTypeMapper()
        {
            CreateMap<CityType, CityTypeDto>().ReverseMap();
        }
    }
}
