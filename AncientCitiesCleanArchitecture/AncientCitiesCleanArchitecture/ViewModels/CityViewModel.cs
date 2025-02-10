using AncientCities.Application.AncientCity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace AncientCities.WebAPI.ViewModels
{
    public class CityViewModel
    {
        public CityDto City { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> CityTypes { get; set; }

        [ValidateNever]
        [Display(Name = "Era")]
        public IEnumerable<SelectListItem> EraNames { get; set; }

        [Display(Name = "Era created")]
        public int? EraCreatedInt { get; set; }

        [Display(Name = "Era defunct")]
        public int? EraDefunctInt { get; set; }
    }
}
