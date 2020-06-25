using EventPlanner.CMS.DataAccess;
using EventPlanner.CMS.Models;
using EventPlanner.CMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;

namespace EventPlanner.CMS.Controllers {
    [Authorize]
    public class PlaceController : Controller {
        // GET: Place
        public ActionResult Index() {
            var model = new Place();
            var vm = model.GetAllPlaces();
            return View("Places", vm);
        }

        private IEnumerable<PlaceType> GetAllPlaceTypes() {

            var db = PlaceTypeDb.GetAllPlaceTypes();
            var types = new List<PlaceType>();
            foreach (DataRow row in db.Rows) {
                var type = new PlaceType();
                type.Id = (int)row["Id"];
                type.Name = (string)row["Name"];
                types.Add(type);
            }
            return types;
        }

        // GET: Place/Create
        public ActionResult Create() {
            PlaceVm vm = new PlaceVm();
            vm.PlaceTypes = GetAllPlaceTypes();
            return View(vm);
        }

        // POST: Place/Create
        [HttpPost]
        public ActionResult Create(PlaceVm vm) {
            try {
                if (!ModelState.IsValid) {
                    return View();
                }

                var model = new Place();
                model.Create(vm);

                return RedirectToAction("Index");
            } catch (Exception ex) {
                return View("Error");
            }
        }

        // GET: Place/Edit/5
        public ActionResult Edit(int id) {
            var row = PlaceDb.GetPlaceById(id).Rows[0];
            PlaceVm vm = new PlaceVm();
            vm.Id = id;
            vm.Name = row["Name"].ToString();
            vm.Address = row["Address"].ToString();
            vm.CostPerHour = (decimal)row["CostPerHour"];
            vm.PlaceTypeId = (int)row["PlaceTypeId"];
            vm.PlaceTypes = GetAllPlaceTypes();
            return View(vm);
        }

        // POST: Place/Edit/5
        [HttpPost]
        public ActionResult Edit(PlaceVm vm) {
            try {
                var model = new Place();
                model.Edit(vm);

                return RedirectToAction("Index");
            } catch (Exception ex) {
                return View("Error");
            }
        }

        // POST: Place/Delete/5
        [HttpPost]
        public ActionResult Delete(int id) {
            try {
                var model = new Place();
                model.Delete(id);

                return RedirectToAction("Index");
            } catch (Exception ex) {
                return View("Error");
            }
        }
    }
}
