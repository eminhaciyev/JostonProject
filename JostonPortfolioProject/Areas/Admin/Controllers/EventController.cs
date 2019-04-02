
using JostonPortfolioProject.DAL;
using JostonPortfolioProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JostonPortfolioProject.Areas.Admin.Controllers
{
    public class EventController : Controller
    {
        // GET: Admin/Event
        private readonly PorfolioDbContext _db;
        public EventController()
        {
            _db = new PorfolioDbContext();

        }

        public ActionResult Index()
        {
            var model = _db.Events.ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null) return HttpNotFound("Id can not be null...");

            var events = _db.Events.Find(id);

            if (events == null) return HttpNotFound("Event can not be null");

            return View(events);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Price,SubTitle,Hours,HowManyPhoto,Content")] Event events)
        {
            if (!ModelState.IsValid) return View(events);

            Event eventBefore = _db.Events.Find(events.Id);
            
            eventBefore.Title = events.Title;
            eventBefore.Price = events.Price;
            eventBefore.SubTitle = events.SubTitle;
            eventBefore.Hours = events.Hours;
            eventBefore.HowManyPhoto = events.HowManyPhoto;
            eventBefore.Content = events.Content;
            _db.SaveChanges();

            return RedirectToAction("Index", "Event");
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null) return HttpNotFound("Id is not found...");

            var events = _db.Events.Find(id);

            if (events == null) return HttpNotFound("Gallery not found...");

            return View(events);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int? id)
        {
            if (id == null) return HttpNotFound("Id is not found...");

            var events = _db.Events.Find(id);

            if (events == null) HttpNotFound("Events not found...");

            

            _db.Events.Remove(events);
            _db.SaveChanges();

            return RedirectToAction("Index", "Event");
        }


    }
}