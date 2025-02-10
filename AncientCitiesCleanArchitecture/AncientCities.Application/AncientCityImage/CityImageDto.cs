using System.ComponentModel.DataAnnotations;
using AncientCities.Application.AncientCity;

namespace AncientCities.Application.AncientCityImage
{
    public class CityImageDto
    {
        public int Id { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        //FK
        public int CityId { get; set; }

        public CityDto City { get; set; }
    }
}
