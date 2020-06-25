using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using EventPlanner.Site.Models;
using EventPlanner.Site.ViewModels;
using Microsoft.AspNet.Identity;

namespace EventPlanner.Site.Controllers {
    [Authorize]
    //[RoutePrefix("api/events")]
    public class EventController : Controller {

        //[OutputCache(Duration = 45, VaryByParam = "id")]
        [OutputCache(CacheProfile = "TestProfile")]
        public ActionResult TestCache(int id)
        {
            return View(DateTime.Now);
        }


        // GET: Event
        //[Route("get-all")]
        [AllowAnonymous]
        public ActionResult Index() {
            var model = new Event();
            var events = model.GetAllEvents();
            return View("Events", events);
        }

        // GET: Event/Details/5
        public ActionResult Details(int id) {
            return View();
        }

        // GET: Event/Create
        [Authorize]
        [Route("create")]
        public ActionResult Create() {
            List<TypeVm> places = new Event().GetPlaces();
            List<TypeVm> eventTypes = new Event().GetAllEventTypes();
            List<ServiceItemVm> servicesSource = new Event().GetAllServices();
            var vm = new EventVm();
            vm.Places = places;
            vm.EventTypes = eventTypes;
            vm.ServicesSource = servicesSource;
            vm.EventTypeId = eventTypes.First().Id;
            return View(vm);
        }

        // POST: Event/Create
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(EventVm vm) {
            try {
                if (!ModelState.IsValid) {
                    //var errors = new List<ModelError>();
                    //foreach (var value in ModelState.Values) {
                    //    foreach (var error in value.Errors) {
                    //        errors.Add(error);
                    //    }
                    //}

                    //TempData["CreateErrors"] = errors;
                    return RedirectToAction("Create");
                }

                vm.Comment = EncodeText(vm.Comment);

                Guid userId = new Guid(User.Identity.GetUserId());
                vm.UserId = userId;

                if (vm.File != null) {
                    var fileName = vm.File.FileName;
                    vm.ImageUrl = Path.Combine("\\Uploads", fileName);
                    // local storage
                    var path = Path.Combine(Server.MapPath("~/Uploads/"), fileName);
                    vm.File.SaveAs(path);
                }

                //List<int> servicesIds = new List<int>();
                //if(vm.ServicesSource != null)
                //{
                //    foreach (var service in vm.ServicesSource)
                //    {
                //        if (service.IsSelected)
                //        {
                //            servicesIds.Add(service.Id);
                //        }
                //    }
                //}

                List<int> servicesIds = vm.ServicesSource.Where(s => s.IsSelected).Select(s => s.Id).ToList();

                vm.ServicesIds = servicesIds;
                var model = new Event();
                model.Create(vm);

                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }

        private string EncodeText(string value)
        {

            var encodedComment = HttpUtility.HtmlEncode(value);
            //var decodedComment = HttpUtility.HtmlDecode(encodedComment);

            var sb = new StringBuilder();

            sb.Append(encodedComment);
            sb.Replace("&lt;b&gt;", "<b>");
            sb.Replace("&lt;/b&gt;", "</b>");

            return sb.ToString();
        }

        // GET: Event/Edit/5
        public ActionResult Edit(int id) {
            return View();
        }

        // POST: Event/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection) {
            try {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }

        // GET: Event/Delete/5
        public ActionResult Delete(int id) {
            return View();
        }

        // POST: Event/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection) {
            try {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }
    }
}
