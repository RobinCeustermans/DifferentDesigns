using System.ComponentModel.DataAnnotations;

namespace AncientCitiesVSA.Features.CityType.DomainModels
{
    public class CityType
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
