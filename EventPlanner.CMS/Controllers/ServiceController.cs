using EventPlanner.CMS.DataAccess;
using EventPlanner.CMS.Models;
using EventPlanner.CMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;

namespace EventPlanner.CMS.Controllers {
    public class ServiceController : Controller {
        // GET: Service
        public ActionResult Index() {
            var model = new Service();
            var vm = model.GetAllServices();
            return View("Services", vm);
        }

        // GET: Service/Create
        public ActionResult Create() {
            ServiceVm vm = new ServiceVm();
            vm.ServiceTypes = GetAllServiceTypes();
            return View(vm);
        }

        // POST: Service/Create
        [HttpPost]
        public ActionResult Create(ServiceVm vm) {
            try {
                if (!ModelState.IsValid) {
                    return View();
                }

                var model = new Service();
                model.Create(vm);

                return RedirectToAction("Index");
            } catch (Exception ex) {
                return View("Error");
            }
        }

        // GET: Service/Edit/5
        public ActionResult Edit(int id) {
            var row = ServiceDb.GetServiceById(id).Rows[0];
            ServiceVm vm = new ServiceVm();
            vm.Id = id;
            vm.Name = row["Name"].ToString();
            vm.CostPerHour = (decimal)row["CostPerHour"];
            vm.ServiceTypeId = (int)row["ServiceTypeId"];
            vm.ServiceTypes = GetAllServiceTypes();
            return View(vm);
        }

        private IEnumerable<ServiceType> GetAllServiceTypes() {

            var db = ServiceTypeDb.GetAllServiceTypes();
            var types = new List<ServiceType>();
            foreach (DataRow row in db.Rows) {
                var type = new ServiceType();
                type.Id = (int)row["Id"];
                type.Name = (string)row["Name"];
                types.Add(type);
            }
            return types;
        }

        // POST: Service/Edit/5
        [HttpPost]
        public ActionResult Edit(ServiceVm vm) {
            try {
                var model = new Service();
                model.Edit(vm);

                return RedirectToAction("Index");
            } catch (Exception ex) {
                return View("Error");
            }
        }

        // POST: Service/Delete/5
        [HttpPost]
        public ActionResult Delete(int id) {
            try {
                var model = new Service();
                model.Delete(id);

                return RedirectToAction("Index");
            } catch (Exception ex) {
                return View("Error");
            }
        }
    }
}
