using AncientCities.Domain.Common.BaseEntities;
using System.ComponentModel.DataAnnotations;

namespace AncientCities.Domain.Aggregates.CityTypeAggregate
{
    public class CityType : AggregateRoot
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        private CityType() { }

        public CityType(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
