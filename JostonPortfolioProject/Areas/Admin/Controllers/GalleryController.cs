using JostonPortfolioProject.DAL;
using JostonPortfolioProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static JostonPortfolioProject.Areas.Admin.FileExtension.Extensions;
using static JostonPortfolioProject.Areas.Admin.Utilities.Utilities;

namespace JostonPortfolioProject.Areas.Admin.Controllers
{
    public class GalleryController : Controller
    {
        private readonly PorfolioDbContext _db;
        public GalleryController()
        {
            _db = new PorfolioDbContext();
        }
        // GET: Admin/Gallery
        public ActionResult Index()
        {
            var model = _db.Galleries.ToList();
            return View(model);
        }
        

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Tag,Photo")] Gallery gallery)
        {
            if (!ModelState.IsValid) return View(gallery);

            if (gallery.Photo == null)
            {
                ModelState.AddModelError("Photo", "Photo can not empty...");
                return View(gallery);
            }

            if (!gallery.Photo.isImage())
            {
                ModelState.AddModelError("Photo", "Photo type is not valid...");
                return View(gallery);
            }

            gallery.Image = gallery.Photo.Save("gallery");

            _db.Galleries.Add(gallery);
            _db.SaveChanges();

            return RedirectToAction("Index", "Gallery");         
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null) return HttpNotFound("Id can not be null...");

            var gallery = _db.Galleries.Find(id);

            if (gallery == null) return HttpNotFound("Gallery can not be null");            

            return View(gallery);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Tag,Photo")] Gallery gallery)
        {
            if (!ModelState.IsValid) return View(gallery);

            Gallery galleryBefore = _db.Galleries.Find(gallery.Id);

            if (gallery.Photo != null)
            {
                if (galleryBefore.Image != null)
                {
                    Remove(galleryBefore.Image);
                }
                galleryBefore.Image = gallery.Photo.Save("gallery");
            }

            if (!gallery.Photo.isImage())
            {
                ModelState.AddModelError("Photo", "Photo type is not image");
                return View(gallery);
            }

            galleryBefore.Tag = gallery.Tag;
            _db.SaveChanges();            

            return RedirectToAction("Index", "Gallery");
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null) return HttpNotFound("Id is not found...");

            var gallery = _db.Galleries.Find(id);

            if (gallery == null) return HttpNotFound("Gallery not found...");

            return View(gallery);           
        }
        [HttpPost]
        [ActionName("Delete")]        
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int? id)
        {
            if (id == null) return HttpNotFound("Id is not found...");

            var gallery = _db.Galleries.Find(id);

            if (gallery == null) HttpNotFound("Gallery not found...");

            Remove(gallery.Image);

            _db.Galleries.Remove(gallery);
            _db.SaveChanges();

            return RedirectToAction("Index","Gallery");
        }


    }
}