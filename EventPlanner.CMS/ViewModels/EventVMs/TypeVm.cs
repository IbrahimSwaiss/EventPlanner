using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EventPlanner.CMS.ViewModels.EventVMs {
    public class TypeVm {
        [Required]
        [Range(0, int.MaxValue)]
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        [DisplayName("Event Types")]
        public string Name { get; set; }
    }
}