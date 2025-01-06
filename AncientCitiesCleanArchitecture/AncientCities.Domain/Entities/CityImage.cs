using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AncientCities.Domain.Entities
{
    public class CityImage
    {
        public int Id { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        //FK
        public int CityId { get; set; }
        [ForeignKey("CityId")]
        public City City { get; set; }
    }
}
