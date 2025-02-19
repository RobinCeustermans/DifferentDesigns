using System.ComponentModel.DataAnnotations;

namespace AncientCities.Application.DTOs
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
