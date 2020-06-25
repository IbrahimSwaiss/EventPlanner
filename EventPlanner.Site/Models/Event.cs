using EventPlanner.Site.DataAccess;
using EventPlanner.Site.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;

namespace EventPlanner.Site.Models {
    public class Event {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int EventTypeId { get; set; }
        public Guid UserId { get; set; }
        public int PlaceId { get; set; }
        //public List<int> ServicesIds { get; set; }

        public List<EventItemVm> GetAllEvents() {
            var events = new List<EventItemVm>();
            DataTable dt = EventDb.GetAllEvents();

            foreach (DataRow row in dt.Rows) {
                var item = new EventItemVm();

                item.Id = (int)row["Id"];
                item.Start = (DateTime)row["Start"];
                item.End = (DateTime)row["End"];
                item.EventType = (string)row["EventType"];
                item.Place = (string)row["Place"];
                item.UserName = (string)row["UserName"];
                item.ImageUrl = row.IsNull("ImageUrl") ? string.Empty : (string)row["ImageUrl"];
                item.Comment = row.IsNull("Comment") ? string.Empty : (string)row["Comment"];

                events.Add(item);
            }

            return events;
        }

        public void Create(EventVm vm) {
            EventDb.Create(vm.Start, vm.End, vm.EventTypeId, vm.PlaceId, vm.UserId, vm.ImageUrl, vm.ServicesIds, vm.Comment);
        }

        public List<TypeVm> GetPlaces() {

            var places = new List<TypeVm>();

            DataTable dt = EventDb.GetAllPlaces();
            foreach (DataRow row in dt.Rows) {
                var type = new TypeVm();

                type.Id = (int)row["Id"];
                type.Name = (string)row["Name"];

                places.Add(type);
            }

            return places;

        }
        public List<TypeVm> GetAllEventTypes() {

            var eventTypes = new List<TypeVm>();

            DataTable dt = EventDb.GetAllEventTypes();
            foreach (DataRow row in dt.Rows) {
                var type = new TypeVm();

                type.Id = (int)row["Id"];
                type.Name = (string)row["Name"];

                eventTypes.Add(type);
            }

            return eventTypes;

        }

        public List<ServiceItemVm> GetAllServices() {
            var source = new List<ServiceItemVm>();
            var dt = EventDb.GetAllServices();
            foreach (DataRow row in dt.Rows) {
                var item = new ServiceItemVm();

                item.Id = (int)row["Id"];
                item.Name = (string)row["Name"];
                item.CostPerHour = (decimal)row["CostPerHour"];
                item.ServiceType = (string)row["ServiceType"];

                source.Add(item);
            }
            return source;
        }
    }
}