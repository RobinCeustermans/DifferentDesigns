using AncientCities.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
