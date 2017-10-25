using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tours.Models;
using Tours.ViewModels;

namespace Tours.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public HomeController()
        {
            _dbContext =new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var tours = _dbContext.Tours.ToList();
            return View(tours);
        }
        // GET: Tour Detail
        public ActionResult TourDetail(int id)
        {
            var tour = _dbContext.Tours.Single(t => t.Id == id);
            var viewModel = new TourViewModel
            {
                Id = id,
                Name = tour.Name,
                Place = tour.Place,
                Price = tour.Price.ToString(),
                Cover = tour.Cover,
                Images1 = tour.Images1,
                Images2 = tour.Images2,
                Description = tour.Description
            };
            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        // GET: NOibat
        public ActionResult NoiBat()
        {
            var tours = _dbContext.Tours
                .Where(t => t.TourNoiBat == true)
                .ToList(); 
            return View(tours);
        }
        // GET
        public ActionResult TimKiem()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KQTimKiem(TourViewModel viewModel)
        {
            var tour = _dbContext.Tours.Single(t => t.Name == viewModel.Name);
            return View(tour);
        }
    }
}