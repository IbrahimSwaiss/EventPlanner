using System;
using System.Web.Mvc;
using EventPlanner.CMS.DataAccess;
using EventPlanner.CMS.Models;
using EventPlanner.CMS.ViewModels.EventVMs;

namespace EventPlanner.CMS.Controllers {
    public class ServiceTypeController : Controller {
        // GET: Service
        public ActionResult Index() {
            var model = new ServiceType();
            var vm = model.GetAllServiceTypes();
            return View("ServiceTypes", vm);
        }

        // GET: ServiceType/Create
        public ActionResult Create() {
            return View();
        }

        // POST: ServiceType/Create
        [HttpPost]
        public ActionResult Create(CreateEditTypeVm vm) {
            try {
                if (!ModelState.IsValid)
                    return View();

                var model = new ServiceType();
                model.Create(vm.Name);

                return RedirectToAction("Index");
            } catch (Exception ex) {
                return View("Error");
            }
        }

        // GET: ServiceType/Edit/5
        public ActionResult Edit(int id) {
            var rows = ServiceTypeDb.GetServiceById(id).Rows;
            CreateEditTypeVm vm = new CreateEditTypeVm();
            vm.Id = id;
            vm.Name = rows[0]["Name"].ToString();
            return View(vm);
        }

        // POST: ServiceType/Edit/5
        [HttpPost]
        public ActionResult Edit(CreateEditTypeVm vm) {
            try {
                var model = new ServiceType();
                model.Edit(vm.Id, vm.Name);

                return RedirectToAction("Index");
            } catch (Exception ex) {
                return View("Error");
            }
        }

        // POST: ServiceType/Delete/5
        [HttpPost]
        public ActionResult Delete(int id) {
            try {
                var model = new ServiceType();
                model.Delete(id);

                return RedirectToAction("Index");
            } catch (Exception ex) {
                return View("Error");
            }
        }
    }
}
