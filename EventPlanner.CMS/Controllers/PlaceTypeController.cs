using EventPlanner.CMS.DataAccess;
using EventPlanner.CMS.Models;
using EventPlanner.CMS.ViewModels.EventVMs;
using System;
using System.Web.Mvc;

namespace EventPlanner.CMS.Controllers {
    public class PlaceTypeController : Controller {
        // GET: PlaceType
        public ActionResult Index() {
            var model = new PlaceType();
            var vm = model.GetAllPlaceTypes();
            return View("PlaceTypes", vm);
        }

        // GET: PlaceType/Create
        public ActionResult Create() {
            return View();
        }

        // POST: PlaceType/Create
        [HttpPost]
        public ActionResult Create(CreateEditTypeVm vm) {
            try {
                if (!ModelState.IsValid) {
                    return View();
                }

                var model = new PlaceType();
                model.Create(vm.Name);

                return RedirectToAction("Index");
            } catch (Exception ex) {
                return View("Error");
            }
        }

        // GET: PlaceType/Edit/5
        public ActionResult Edit(int id) {
            var rows = PlaceTypeDb.GetPlaceById(id).Rows;
            CreateEditTypeVm vm = new CreateEditTypeVm();
            vm.Id = id;
            vm.Name = rows[0]["Name"].ToString();
            return View(vm);
        }

        // POST: PlaceType/Edit/5
        [HttpPost]
        public ActionResult Edit(CreateEditTypeVm vm) {
            try {
                var model = new PlaceType();
                model.Edit(vm.Id, vm.Name);

                return RedirectToAction("Index");
            } catch (Exception ex) {
                return View("Error");
            }
        }

        // POST: PlaceType/Delete/5
        [HttpPost]
        public ActionResult Delete(int id) {
            try {
                var model = new PlaceType();
                model.Delete(id);

                return RedirectToAction("Index");
            } catch (Exception ex) {
                return View("Error");
            }
        }
    }
}
