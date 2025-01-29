using AncientCities.Application.DTOs;
using AncientCities.Domain.Entities;
using AutoMapper;

namespace AncientCities.Application.Mappers
{
    public class CityTypeMapper : Profile
    {
        public CityTypeMapper()
        {
            CreateMap<CityType, CityTypeDto>().ReverseMap();
        }
    }
}
