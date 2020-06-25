using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using EventPlanner.Site.Attributes;

namespace EventPlanner.Site.ViewModels {
    public class EventVm {
        public int Id { get; set; }
        [FutureDate]
        public DateTime Start { get; set; } = DateTime.Now;
        [FutureDate]
        public DateTime End { get; set; } = DateTime.Now.AddHours(1);
        public int EventTypeId { get; set; }
        public Guid UserId { get; set; }
        public int PlaceId { get; set; }

        public HttpPostedFileBase File { get; set; }
        public string ImageUrl { get; set; }

        public List<TypeVm> Places { get; set; }
        public List<TypeVm> EventTypes { get; set; }

        public List<ServiceItemVm> ServicesSource { get; set; }
        public List<int> ServicesIds { get; set; }

        public string Comment { get; set; }
    }
}