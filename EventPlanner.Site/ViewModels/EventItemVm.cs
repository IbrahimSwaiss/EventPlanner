using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace EventPlanner.Site.ViewModels {
    public class EventItemVm {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        [DisplayName("Event type")]
        public string EventType { get; set; }
        public string Place { get; set; }

        [DisplayName("Username")]
        public string UserName { get; set; }

        [DisplayName("Image")]
        public string ImageUrl { get; set; }

        public string Comment { get; set; }
    }
}