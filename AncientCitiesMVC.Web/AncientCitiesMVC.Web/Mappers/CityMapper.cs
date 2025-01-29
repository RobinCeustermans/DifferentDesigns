using AncientCitiesMVC.Models;
using AutoMapper;

namespace AncientCitiesMVC.Web.Mappers
{
    public class CityMapper : Profile
    {
        public CityMapper()
        {
            CreateMap<City, City>()
                .ForMember(dest => dest.CityImages, opt => opt.Ignore());
        }
    }
}
