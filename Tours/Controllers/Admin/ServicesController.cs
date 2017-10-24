using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tours.Models;
using Tours.ViewModels;

namespace Tours.Controllers.Admin
{
    public class ServicesController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public ServicesController()
        {
            _dbContext = new ApplicationDbContext();
        }

        [Authorize]
        // GET: Services
        public ActionResult Index()
        {
            var services = _dbContext.Services.ToList();
            return View(services);
        }

        // GET: Services/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Services/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Services/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ServiceViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Create");
            }
            var service = new Service
            {
                Name = viewModel.Name,
                Price = decimal.Parse(viewModel.Price),
                Description = viewModel.Description
            };
            _dbContext.Services.Add(service);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Services/Edit/5
        public ActionResult Edit(int id)
        {
            var service = _dbContext.Services.Single(s => s.Id == id);
            var viewModel = new ServiceViewModel
            {
                Id = service.Id,
                Name = service.Name,
                Price = service.Price.ToString(),
                Description = service.Description
            };
            return View(viewModel);
        }

        // POST: Services/Edit/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ServiceViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            var service = _dbContext.Services.Single(s => s.Id == viewModel.Id);
            service.Name = viewModel.Name;
            service.Price = decimal.Parse(viewModel.Price);
            service.Description = viewModel.Description;
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Services/Delete/5
        public ActionResult Delete(int id)
        {
            var service = _dbContext.Services.Single(s => s.Id == id);
            var viewModel = new ServiceViewModel
            {
                Id = service.Id,
                Name = service.Name,
                Price = service.Price.ToString(),
                Description = service.Description
            };
            return View(viewModel);
        }

        // POST: Services/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Delete(ServiceViewModel viewModel)
        {
            try
            {
                var service = _dbContext.Services.Single(v => v.Id == viewModel.Id);
                _dbContext.Services.Remove(service);
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
