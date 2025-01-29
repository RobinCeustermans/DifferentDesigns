using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace AncientCities.Domain.Entities
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name = "Part of")]
        public string PartOf { get; set; }

        [Display(Name = "Estimated population")]
        public int? Population { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Created { get; set; }

        [Display(Name = "Before or after Christ")]
        public string? EraCreated { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Defunct { get; set; }

        [Display(Name = "Before or after Christ")]
        public string? EraDefunct { get; set; }

        public string? Description { get; set; }



        //Foreign Key
        [Display(Name = "City type")]
        public int? TypeId { get; set; }

        [Display(Name = "City type")]
        public CityType? Type { get; set; }

        [Display(Name = "Image")]

        [ValidateNever]
        public List<CityImage> CityImages { get; set; }
    }
}
