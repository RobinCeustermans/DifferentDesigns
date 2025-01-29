using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AncientCitiesMVC.Models
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
