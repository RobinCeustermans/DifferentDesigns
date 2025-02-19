using AncientCities.Domain.Common.BaseEntities;
using System.ComponentModel.DataAnnotations;

namespace AncientCities.Domain.Aggregates.CityAggregate
{
    public class CityImage : AggregateRoot
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public CityImage(int id, string imageUrl)
        {
            Id = id;
            ImageUrl = imageUrl;
        }

        public CityImage()
        {
        }

        //FK
        public int CityId { get; set; }
        public City City { get; set; }
    }
}
