using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrashCollectorV2.Contracts;

namespace TrashCollectorV2.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IRepositoryWrapper _repo;
        public EmployeeController(IRepositoryWrapper repo)
        {
            _repo = repo;
        }
        // GET: Employee
        public ActionResult Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (_repo.Customer.FindByCondition(a => a.UserId == userId).Any())
            {
                var employee = _repo.Employee.FindByCondition(b => b.UserId == userId).FirstOrDefault();
                var customers = _repo.Customer.GetCustomerIncludeAll();
                var customersInArea = customers.Where(a => a.Address.ZipCode == employee.ZipCode).ToList();
                var activeCustomers = new List<Models.Customer>();
                foreach (var item in customersInArea)
                {
                    if (item.Account.IsSuspended == true && !(DateTime.Now.CompareTo(item.Account.StartDate) > 0 && DateTime.Now.CompareTo(item.Account.EndDate) < 0))
                    {
                        activeCustomers.Add(item);
                    }
                    else if (item.Account.IsSuspended == false)
                    {
                        activeCustomers.Add(item);
                    }
                    else
                    {
                        continue;
                    }
                }
                var customersWithTodayPickup = activeCustomers.Where(a => a.Account.NextPickup.Date == DateTime.Now.Date || a.Account.OneTimePickup.Date == DateTime.Now.Date).ToList();
                return View(customersWithTodayPickup);
            }
            else
            {
                return RedirectToAction("Create");
            }
            
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}