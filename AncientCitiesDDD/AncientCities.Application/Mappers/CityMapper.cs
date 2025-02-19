using AncientCities.Application.DTOs;
using AncientCities.Domain.Aggregates.CityAggregate;
using AutoMapper;

namespace AncientCities.Application.Mappers
{
    public class CityMapper : Profile
    {
        public CityMapper()
        {
            CreateMap<City, CityDto>().ReverseMap();
        }
    }
}
