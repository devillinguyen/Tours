using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tours.Models;
using Tours.ViewModels;

namespace Tours.Controllers.Admin
{
    public class ToursController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public ToursController()
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: Tours
        [Authorize]
        public ActionResult Index()
        {
            var tours = _dbContext.Tours.ToList();
            return View(tours);
        }

        // GET: Tours/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Tours/Create
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        // POST: Tours/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TourViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Create");
            }
            var tour = new Tour
            {
                Name = viewModel.Name,
                Place = viewModel.Place,
                Price = decimal.Parse(viewModel.Price),
                Cover = viewModel.Cover,
                Images1 = viewModel.Images1,
                Images2 = viewModel.Images2,
                Description = viewModel.Description
            };
            _dbContext.Tours.Add(tour);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Tours/Edit/5
        public ActionResult Edit(int id)
        {
            var tour = _dbContext.Tours.Single(t => t.Id == id);
            var viewModel = new TourViewModel
            {
                Id = tour.Id,
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

        [Authorize(Roles = "Admin")]
        // POST: Tours/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TourViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            var tour = _dbContext.Tours.Single(t => t.Id == viewModel.Id);
            tour.Name = viewModel.Name;
            tour.Place = viewModel.Place;
            tour.Price = decimal.Parse(viewModel.Price);
            tour.Cover = viewModel.Cover;
            tour.Images1 = viewModel.Images1;
            tour.Images2 = viewModel.Images2;
            tour.Description= viewModel.Description;
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Tours/Delete/5
        public ActionResult Delete(int id)
        {
            var tour = _dbContext.Tours.Single(t => t.Id == id);
            var viewModel = new TourViewModel
            {
                Id = tour.Id,
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

        [Authorize(Roles = "Admin")]
        // POST: Tours/Delete/5
        [HttpPost]
        public ActionResult Delete(TourViewModel viewModel)
        {
            try
            {
                var tour = _dbContext.Tours.Single(t => t.Id == viewModel.Id);
                _dbContext.Tours.Remove(tour);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(viewModel);
            }
        }
    }
}
