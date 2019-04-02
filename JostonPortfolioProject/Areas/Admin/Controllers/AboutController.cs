using JostonPortfolioProject.Areas.Admin.FileExtension;
using JostonPortfolioProject.DAL;
using JostonPortfolioProject.Models;
using JostonPortfolioProject.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static JostonPortfolioProject.Areas.Admin.Utilities.Utilities;

namespace JostonPortfolioProject.Areas.Admin.Controllers
{
    public class AboutController : Controller
    {
        // GET: Admin/About
        private readonly PorfolioDbContext _db;
        public AboutController()
        {
            _db = new PorfolioDbContext();
        }

        public ActionResult Index()
        {
            var model = _db.Abouts.ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title, Content,Photo")]  About about)
        {
            if (!ModelState.IsValid) return View(about);

            if (about.Photo == null)
            {
                ModelState.AddModelError("Photo", "Photo can not be null");
                return View(about);
            }

            if (!about.Photo.isImage())
            {
                ModelState.AddModelError("Photo", "Photo type is not valid");
                return View(about);
            }

            about.Image = about.Photo.Save("about");

            _db.Abouts.Add(about);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index), "About");
        }


        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null) return HttpNotFound("Id not found...");

            var about = _db.Abouts.Find(id);

            if (about == null) return HttpNotFound("Hemin Id-ye uygun post tapilmadi...");

            return View(about);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, Title, Content, Photo")] About about)
        {
            if (!ModelState.IsValid) return View(about);

            About aboutBefore = _db.Abouts.Find(about.Id);

            if (about.Photo != null)
            {
                if (aboutBefore.Image != null)
                {
                    Remove(aboutBefore.Image);
                }
                aboutBefore.Image = about.Photo.Save("about");
            }

            aboutBefore.Title = about.Title;
            aboutBefore.Content = about.Content;
            _db.SaveChanges();

            return RedirectToAction(nameof(Index), "About");
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if(id == null) return HttpNotFound("Id not found...");

            var about = _db.Abouts.Find(id);

            if (about == null) return HttpNotFound("this post not found...");

            return View(about);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int? id)
        {
            if (id == null) return HttpNotFound("Id not found...");

            var about = _db.Abouts.Find(id);

            if (about == null) return HttpNotFound("this post not found...");

            Remove(about.Image);

            _db.Abouts.Remove(about);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index),"About");
        }
    }
}