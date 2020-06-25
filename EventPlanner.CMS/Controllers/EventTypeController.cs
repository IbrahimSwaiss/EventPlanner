using System;
using System.Web.Mvc;
using EventPlanner.CMS.DataAccess;
using EventPlanner.CMS.Models;
using EventPlanner.CMS.ViewModels.EventVMs;

namespace EventPlanner.CMS.Controllers {
    [Authorize]
    public class EventTypeController : Controller {
        // GET: Event
        [AllowAnonymous]
        public ActionResult Index() {
            var model = new EventType();
            var vm = model.GetAllEventTypes();
            return View("EventTypes", vm);
        }

        // GET: EventType/Create
        public ActionResult Create() {
            return View();
        }

        // POST: EventType/Create
        [HttpPost]
        public ActionResult Create(CreateEditTypeVm vm) {
            try {
                if (!ModelState.IsValid)
                    return View();

                var model = new EventType();
                model.Create(vm.Name);

                return RedirectToAction("Index");
            } catch (Exception ex) {
                return View("Error");
            }
        }

        // GET: EventType/Edit/5
        public ActionResult Edit(int id) {
            var rows = EventTypeDb.GetEventById(id).Rows;
            CreateEditTypeVm vm = new CreateEditTypeVm();
            vm.Id = id;
            vm.Name = rows[0]["Name"].ToString();
            return View(vm);
        }

        // POST: EventType/Edit/5
        [HttpPost]
        public ActionResult Edit(CreateEditTypeVm vm) {
            try {
                var model = new EventType();
                model.Edit(vm.Id, vm.Name);

                return RedirectToAction("Index");
            } catch (Exception ex) {
                return View("Error");
            }
        }

        // POST: EventType/Delete/5
        [HttpPost]
        public ActionResult Delete(int id) {
            try {
                var model = new EventType();
                model.Delete(id);

                return RedirectToAction("Index");
            } catch (Exception ex) {
                return View("Error");
            }
        }
    }
}
