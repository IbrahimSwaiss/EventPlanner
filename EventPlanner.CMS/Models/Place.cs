using System.Collections.Generic;
using System.Data;
using EventPlanner.CMS.DataAccess;
using EventPlanner.CMS.ViewModels;

namespace EventPlanner.CMS.Models {
    public class Place {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal CostPerHour { get; set; }
        public int PlaceTypeId { get; set; }

        public List<ViewPlaceVm> GetAllPlaces() {
            var db = PlaceDb.GetAllPlaces();
            var places = new List<ViewPlaceVm>();
            foreach (DataRow row in db.Rows) {
                var vm = new ViewPlaceVm();
                vm.Id = (int)row["Id"];
                vm.Name = (string)row["Name"];
                vm.CostPerHour = (decimal)row["CostPerHour"];
                vm.PlaceType = (string)row["PlaceType"];
                vm.Address = (string)row["Address"];
                places.Add(vm);
            }
            return places;
        }

        public void Create(PlaceVm vm) {
            Place place = new Place();
            place.Name = vm.Name;
            place.CostPerHour = vm.CostPerHour;
            place.Address = vm.Address;
            place.PlaceTypeId = vm.PlaceTypeId;
            PlaceDb.Create(place);
        }

        public void Edit(PlaceVm vm) {
            Place place = new Place();
            place.Id = vm.Id;
            place.Name = vm.Name;
            place.CostPerHour = vm.CostPerHour;
            place.Address = vm.Address;
            place.PlaceTypeId = vm.PlaceTypeId;
            PlaceDb.Edit(place);
        }

        public void Delete(int id) {
            PlaceDb.Delete(id);
        }
    }
}