using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tours.Models;
using Tours.ViewModels;

namespace Tours.Controllers.Admin
{
    public class VehiclesController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public VehiclesController()
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: Vehicle
        [Authorize]
        public ActionResult Index()
        {
            var vehicles = _dbContext.Vehicles.ToList();
            return View(vehicles);
        }
        
        // GET: Vehicle/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Vehicle/Create
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        // POST: Vehicle/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VehicleViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Create");
            }
            var vehicle = new Vehicle
            {
                Name = viewModel.Name,
                Seat = viewModel.Seat,
                Price = decimal.Parse(viewModel.Price),
            };
            _dbContext.Vehicles.Add(vehicle);
            _dbContext.SaveChanges();
            return RedirectToAction("Index","Vehicles");
        }

        // GET: Vehicle/Edit/5
        public ActionResult Edit(int id)
        {
            var vehicle = _dbContext.Vehicles.Single(v => v.Id == id);
            var viewModel = new VehicleViewModel
            {
                Id = vehicle.Id,
                Name = vehicle.Name,
                Seat = vehicle.Seat,
                Price = vehicle.Price.ToString()
            };
            return View("Edit", viewModel);
        }

        [Authorize(Roles = "Admin")]
        // POST: Vehicle/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VehicleViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit");
            }
            var vehicle = _dbContext.Vehicles.Single(v => v.Id == viewModel.Id);
            vehicle.Name = viewModel.Name;
            vehicle.Price = decimal.Parse(viewModel.Price);
            _dbContext.SaveChanges();
            return RedirectToAction("Index","Vehicles");
        }

        // GET: Vehicle/Delete/5
        public ActionResult Delete(int id)
        {
            var vehicle = _dbContext.Vehicles.Single(v => v.Id == id);
            var viewModel = new VehicleViewModel
            {
                Id = vehicle.Id,
                Name = vehicle.Name,
                Seat = vehicle.Seat,
                Price = vehicle.Price.ToString()
            };
            return View(viewModel);
        }

        [Authorize(Roles = "Admin")]
        // POST: Vehicle/Delete/5
        [HttpPost]
        public ActionResult Delete(VehicleViewModel viewModel)
        {
            try
            {
                var vehicle = _dbContext.Vehicles.Single(v => v.Id == viewModel.Id);
                _dbContext.Vehicles.Remove(vehicle);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Delete");
            }
        }
    }
}
