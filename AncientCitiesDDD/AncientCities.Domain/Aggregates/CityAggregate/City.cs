using AncientCities.Domain.Aggregates.CityTypeAggregate;
using AncientCities.Domain.Common.BaseEntities;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace AncientCities.Domain.Aggregates.CityAggregate
{
    public class City : AggregateRoot
    {
        [Key]
        public int Id { get; private set; }

        [Required]
        public string Name { get; private set; }

        public string PartOf { get; private set; }

        public int? Population { get; private set; }

        public DateTime? Created { get; private set; }

        public string? EraCreated { get; private set; }

        public DateTime? Defunct { get; private set; }

        public string? EraDefunct { get; private set; }

        public string? Description { get; private set; }

        // Foreign Key
        public int? TypeId { get; private set; }
        public CityType? Type { get; private set; }

        [Display(Name = "Image")]
        [ValidateNever]
        public List<CityImage> CityImages { get; set; }

        private City() { } 

        public City(int id, string name, string partOf, int? population, DateTime? created, string? eraCreated, DateTime? defunct, string? eraDefunct, string? description, int? typeId)
        {
            Id = id;
            Name = name;
            PartOf = partOf;
            Population = population;
            Created = created;
            EraCreated = eraCreated;
            Defunct = defunct;
            EraDefunct = eraDefunct;
            Description = description;
            TypeId = typeId;
        }
    }
}
