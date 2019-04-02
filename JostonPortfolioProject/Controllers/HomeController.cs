using JostonPortfolioProject.DAL;
using JostonPortfolioProject.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JostonPortfolioProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly PorfolioDbContext _db;
        public HomeController()
        {
            _db = new PorfolioDbContext();
        }

        public ActionResult Index()
        {
            var vm = new ViewModelClasses()
            {
                Gallery = _db.Galleries.ToList(),
                About = _db.Abouts.ToList(),
                Event = _db.Events.ToList()
            };
            return View(vm);
        }        

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}