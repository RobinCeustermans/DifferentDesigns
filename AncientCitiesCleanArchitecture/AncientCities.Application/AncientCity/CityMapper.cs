using AncientCities.Domain.Entities;
using AutoMapper;

namespace AncientCities.Application.AncientCity
{
    public class CityMapper : Profile
    {
        public CityMapper()
        {
            CreateMap<City, CityDto>().ReverseMap();
        }
    }
}
