using System.Collections.Generic;
using System.Data;
using EventPlanner.CMS.DataAccess;
using EventPlanner.CMS.ViewModels;

namespace EventPlanner.CMS.Models {
    public class Service {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal CostPerHour { get; set; }
        public int ServiceTypeId { get; set; }

        public List<ViewServiceVm> GetAllServices() {
            var db = ServiceDb.GetAllServices();
            var services = new List<ViewServiceVm>();
            foreach (DataRow row in db.Rows) {
                var vm = new ViewServiceVm();
                vm.Id = (int)row["Id"];
                vm.Name = (string)row["Name"];
                vm.CostPerHour = (decimal)row["CostPerHour"];
                vm.ServiceType = (string)row["ServiceType"];
                services.Add(vm);
            }
            return services;
        }

        public void Create(ServiceVm vm)
        {
            Service service = new Service();
            service.Name = vm.Name;
            service.CostPerHour = vm.CostPerHour;
            service.ServiceTypeId = vm.ServiceTypeId;
            ServiceDb.Create(service);
        }

        public void Edit(ServiceVm vm) {
            Service service = new Service();
            service.Id = vm.Id;
            service.Name = vm.Name;
            service.CostPerHour = vm.CostPerHour;
            service.ServiceTypeId = vm.ServiceTypeId;
            ServiceDb.Edit(service);
        }

        public void Delete(int id) {
            ServiceDb.Delete(id);
        }

    }
}