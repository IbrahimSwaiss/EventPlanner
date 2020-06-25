using EventPlanner.CMS.ViewModels.EventVMs;
using System.Collections.Generic;
using System.Data;
using EventPlanner.CMS.DataAccess;

namespace EventPlanner.CMS.Models {
    public class EventType {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<TypeVm > GetAllEventTypes() {
            var db = EventTypeDb.GetAllEventTypes();
            var types = new List<TypeVm>();
            foreach (DataRow row in db.Rows) {
                var type = new TypeVm();
                type.Id = (int)row["Id"];
                type.Name = (string)row["Name"];
                types.Add(type);
            }
            return types;
        }

        public void Create(string name) {
            EventTypeDb.Create(name);
        }

        public void Edit(int id, string name) {
            EventTypeDb.Edit(id, name);
        }

        public void Delete(int id) {
            EventTypeDb.Delete(id);
        }
    }
}