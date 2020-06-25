using System.Collections.Generic;

namespace EventPlanner.CMS.ViewModels.EventVMs {
    public class EditEventVm {
        public string Name { get; set; }
        public int PlaceId { get; set; }
        public List<int> ServicesIds { get; set; }
    }
}