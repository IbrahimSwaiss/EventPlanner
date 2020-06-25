using EventPlanner.CMS.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EventPlanner.CMS.ViewModels {
    public class PlaceVm {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        [DisplayName("Cost Per Hour")]
        public decimal CostPerHour { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int PlaceTypeId { get; set; }

        [Required]
        [StringLength(100)]
        public string Address { get; set; }
        
        public IEnumerable<PlaceType> PlaceTypes { get; set; }
    }
}