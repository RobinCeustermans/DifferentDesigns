using AncientCitiesVSA.Features.CityType.DTOs;
using AutoMapper;

namespace AncientCitiesVSA.Features.CityType.Mappers
{
    public class CityTypeMapper : Profile
    {
        public CityTypeMapper()
        {
            CreateMap<DomainModels.CityType, CityTypeDTO>().ReverseMap();
        }
    }
}
