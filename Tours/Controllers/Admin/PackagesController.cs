using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tours.Models;
using Tours.ViewModels;

namespace Tours.Controllers.Admin
{
    public class PackagesController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public PackagesController()
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: Packages
        [Authorize]
        public ActionResult Index()
        {
            var packages = _dbContext.Packages
                .Include(t => t.Tour)
                .Include(s => s.Service)
                .Include(v => v.Vehicle)
                .ToList();
            return View(packages);
        }

        // GET: Packages/Details/5
        public ActionResult Details(int id)
        {
            var package = _dbContext.Packages.Single(p => p.Id == id);
            var viewModel = new PackageViewModel
            {
                Id = id,
                Tour = _dbContext.Tours.Single(t => t.Id == package.TourId),
                Service = _dbContext.Services.Single(s => s.Id == package.ServiceId),
                Vehicle = _dbContext.Vehicles.Single(v => v.Id == package.VehicleId),
                TourId = package.TourId,
                ServiceId = package.ServiceId,
                VehicleId = package.VehicleId,
                Quantity = package.QuantityVehi.ToString(),
                Total = package.Total.ToString(),
                CustomerName = package.CustomerName,
                CustomerEmail = package.CustomerEmail,
                CustomerPhoneNumber = package.CustomerPhoneNumber,
                CustomerAddress = package.CustomerAddress
            };
            return View(viewModel);
        }

        // GET: Packages/Create
        public ActionResult Create(int id)
        {
            var tour = _dbContext.Tours.Single(t => t.Id == id);
            var viewModel = new PackageViewModel
            {
                TourId = tour.Id,
                Services = _dbContext.Services.ToList(),
                Vehicles = _dbContext.Vehicles.ToList()
            };
            return View(viewModel);
        }

        // POST: Packages/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PackageViewModel viewModel)
        {
            /*try
            {
                var package = new Package
                {
                    TourId = viewModel.TourId,
                    ServiceId = viewModel.ServiceId,
                    VehicleId = viewModel.VehicleId
                };
                _dbContext.Packages.Add(package);
                _dbContext.SaveChanges();
                return RedirectToAction("Index","Home");
            }
            catch
            {
                return View("Create", viewModel);
            }*/
            if (!ModelState.IsValid)
            {
                var tmptour = _dbContext.Tours.Single(t => t.Id == viewModel.TourId);
                viewModel.TourId = tmptour.Id;
                viewModel.Services = _dbContext.Services.ToList();
                viewModel.Vehicles = _dbContext.Vehicles.ToList();
                return View("Create", viewModel);
            }
            // Create tmp variables
            var tour = _dbContext.Tours.Single(t => t.Id == viewModel.TourId);
            var service = _dbContext.Services.Single(s => s.Id == viewModel.ServiceId);
            var vehicle = _dbContext.Vehicles.Single(v => v.Id == viewModel.VehicleId);
            int quantity = int.Parse(viewModel.Quantity);
            decimal total = quantity * tour.Price + service.Price + vehicle.Price;
            var package = new Package
            {
                TourId = tour.Id,
                ServiceId = viewModel.ServiceId,
                VehicleId = viewModel.VehicleId,
                QuantityVehi = quantity,
                Total = total,
                CustomerName = viewModel.CustomerName,
                CustomerEmail = viewModel.CustomerEmail,
                CustomerPhoneNumber = viewModel.CustomerPhoneNumber,
                CustomerAddress = viewModel.CustomerAddress
            };
            
            _dbContext.Packages.Add(package);
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        // GET: Packages/Edit/5
        public ActionResult Edit(int id)
        {
            var package = _dbContext.Packages.Single(p => p.Id == id);
            var viewModel = new PackageViewModel
            {
                Id = id,
                TourId = package.TourId,
                ServiceId = package.ServiceId,
                VehicleId = package.VehicleId,
                Quantity = package.QuantityVehi.ToString(),
                Total = package.Total.ToString(),
                Tours = _dbContext.Tours.ToList(),
                Services = _dbContext.Services.ToList(),
                Vehicles = _dbContext.Vehicles.ToList(),
                CustomerName = package.CustomerName,
                CustomerEmail = package.CustomerEmail,
                CustomerPhoneNumber = package.CustomerPhoneNumber,
                CustomerAddress = package.CustomerAddress
            };
            return View(viewModel);
        }

        // POST: Packages/Edit/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PackageViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Tours = _dbContext.Tours.ToList();
                viewModel.Services = _dbContext.Services.ToList();
                viewModel.Vehicles = _dbContext.Vehicles.ToList();
                return View(viewModel);
            }
            var package = _dbContext.Packages.Single(p => p.Id == viewModel.Id); // Gọi đến package đó
            // replace
            package.TourId = viewModel.TourId;
            package.ServiceId = viewModel.ServiceId;
            package.VehicleId = viewModel.VehicleId;
            package.QuantityVehi = int.Parse(viewModel.Quantity);
            // create tmp variables
            var tour = _dbContext.Tours.Single(t => t.Id == viewModel.TourId);
            var service = _dbContext.Services.Single(t => t.Id == viewModel.ServiceId);
            var vehicle = _dbContext.Vehicles.Single(t => t.Id == viewModel.VehicleId);
            decimal total = tour.Price + service.Price + vehicle.Price * package.QuantityVehi;
            package.Total = total;
            package.CustomerName = viewModel.CustomerName;
            package.CustomerEmail = viewModel.CustomerEmail;
            package.CustomerPhoneNumber = viewModel.CustomerPhoneNumber;
            package.CustomerAddress = viewModel.CustomerAddress;
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Packages/Delete/5
        public ActionResult Delete(int id)
        {
            var package = _dbContext.Packages.Single(p => p.Id == id);

            var viewModel = new PackageViewModel
            {
                Id = package.Id,
                TourId = package.TourId,
                ServiceId = package.ServiceId,
                VehicleId = package.VehicleId,
                Quantity = package.QuantityVehi.ToString(),
                Total = package.Total.ToString(),
                Tour = _dbContext.Tours.Single(t => t.Id == package.TourId), // Gọi đến bảng Tours
                Service = _dbContext.Services.Single(s => s.Id == package.ServiceId), // Gọi đến bảng Services
                Vehicle = _dbContext.Vehicles.Single(v => v.Id == package.VehicleId), //Gọi đến bảng Vehicles
                CustomerName = package.CustomerName,
                CustomerEmail = package.CustomerEmail,
                CustomerPhoneNumber = package.CustomerPhoneNumber,
                CustomerAddress = package.CustomerAddress
            };
            return View(viewModel);
        }

        // POST: Packages/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Delete(PackageViewModel viewModel)
        {
            var package = _dbContext.Packages.Single(p => p.Id == viewModel.Id);
            _dbContext.Packages.Remove(package);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
