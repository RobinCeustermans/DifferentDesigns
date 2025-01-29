using AncientCities.Domain.Entities;

namespace AncientCities.Application.DTOs
{
    public class CityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PartOf { get; set; }
        public int? Population { get; set; }
        public DateTime? Created { get; set; }
        public string? EraCreated { get; set; }
        public DateTime? Defunct { get; set; }
        public string? EraDefunct { get; set; }
        public string? Description { get; set; }

        //Foreign Key
        public int? TypeId { get; set; }
        public CityType? Type { get; set; }
        public List<CityImage>? CityImages { get; set; }
    }
}
