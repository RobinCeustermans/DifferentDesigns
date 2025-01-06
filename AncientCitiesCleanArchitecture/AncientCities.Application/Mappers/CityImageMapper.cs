using AncientCities.Application.DTOs;
using AncientCities.Domain.Entities;
using AutoMapper;

namespace AncientCities.Application.Mappers
{
    public class CityImageMapper : Profile
    {
        public CityImageMapper() 
        {
            CreateMap<CityImage, CityImageDto>().ReverseMap();
        }
    }
}
