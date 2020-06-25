using System.Collections.Generic;
using System.Data;
using EventPlanner.CMS.DataAccess;
using EventPlanner.CMS.ViewModels.EventVMs;

namespace EventPlanner.CMS.Models
{
    public class PlaceType {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<TypeVm> GetAllPlaceTypes() {
            var db = PlaceTypeDb.GetAllPlaceTypes();
            var types = new List<TypeVm>();
            foreach (DataRow row in db.Rows) {
                var type = new TypeVm();
                type.Id = (int)row["Id"];
                type.Name = (string)row["Name"];
                types.Add(type);
            }
            return types;
        }

        public void Edit(int id, string name) {
            PlaceTypeDb.Edit(id, name);
        }

        public void Delete(int id) {
            PlaceTypeDb.Delete(id);
        }

        public void Create(string name)
        {
            PlaceTypeDb.Create(name);
        }
    }
}