using Events.Model;
using Events.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Events.View.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EventController : Controller
    {
        IServiceContext _serviceContext;
        const int size = 10;
        public  EventController(IServiceContext serviceContext)
        {
            _serviceContext  = serviceContext;
        }
        // GET: Admin/Event
        public ActionResult Index()
        {
            ViewBag.NextIndex = size;
            return View();
           
        }

        public ActionResult GetFromIndex(int startIndex)
        {
            
            List<Event> eventList = _serviceContext.EventService.GetFromIndex(startIndex, size);
           
            return PartialView("_EventRows", eventList);

        }

        // GET: Events/Create
        public ActionResult Create()
        {
            List<Country> counries = _serviceContext.CountryService.GetAll();
            if (counries.Count > 0)
            {
                ViewBag.CityId = new SelectList(_serviceContext.CityService.GetByCountry(_serviceContext.CountryService.GetAll().First().Id), "Id", "Name");
                ViewBag.CountryId = new SelectList(_serviceContext.CountryService.GetAll(), "Id", "Name");
            }
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Event @event, HttpPostedFileBase file)
        {
            if (file != null)
            {
                @event.Id = -1;
                @event.ImagePath = ConfigurationManager.AppSettings.Get("eventImagePath") + file.FileName;
                ModelState["ImagePath"].Errors.Clear();
                ModelState["Id"].Errors.Clear();
            }
            else
            {
                PopulateLists(@event);
                ModelState.AddModelError("", Resource.MustUploadImage);
                return View(@event);

            }
            if (ModelState.IsValid)
            {
                 SaveImage(file);
                _serviceContext.EventService.AddNew(@event);
                _serviceContext.Complete();
                return RedirectToAction("Index");
            }

            PopulateLists(@event);
            return View(@event);
        }

        // GET: Events/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = _serviceContext.EventService.Get(id.Value);
            if (@event == null)
            {
                return HttpNotFound();
            }
            PopulateLists(@event);

            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Event @event , HttpPostedFileBase file)
        {
            if (file != null)
            {
                @event.ImagePath = ConfigurationManager.AppSettings.Get("eventImagePath") + file.FileName;
                ModelState["ImagePath"].Errors.Clear();
            }
            else
            {
                PopulateLists(@event);
                ModelState.AddModelError("", Resource.MustUploadImage);
                return View(@event);

            }
            UpdateModel(@event);
            if (ModelState.IsValid)
            {
                 SaveImage(file);
                _serviceContext.EventService.Edit(@event);
                _serviceContext.Complete();
                return RedirectToAction("Index");
            }
            PopulateLists(@event);
            return View(@event);
        }

        private void SaveImage(HttpPostedFileBase file)
        {
            byte[] imageData = new byte[file.ContentLength];
            file.InputStream.Read(imageData, 0, file.ContentLength);
            var filename = file.FileName;
            var filePath = Server.MapPath(ConfigurationManager.AppSettings.Get("eventImagePath"));
            string savedFileName = Path.Combine(filePath, filename);
            file.SaveAs(savedFileName);
        }

        private void PopulateLists(Event @event)
        {
            ViewBag.CityId = new SelectList(_serviceContext.CityService.GetByCountry(@event.CountryId), "Id", "Name", @event.CityId);
            ViewBag.CountryId = new SelectList(_serviceContext.CountryService.GetAll(), "Id", "Name", @event.CountryId);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = _serviceContext.EventService.Get(id.Value);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _serviceContext.EventService.Delete(id);
            _serviceContext.Complete();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _serviceContext.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult GetCities(int  countryId)
        {
            List<City> cities = _serviceContext.CityService.GetByCountry(countryId);
            return Json(cities, JsonRequestBehavior.AllowGet);
        }
        



    }
}