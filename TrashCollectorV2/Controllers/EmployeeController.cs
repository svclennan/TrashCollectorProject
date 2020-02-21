using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrashCollectorV2.Contracts;
using TrashCollectorV2.Models;

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
            if (_repo.Employee.FindByCondition(a => a.UserId == userId).Any())
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
        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            try
            {
                var newEmployee = new Employee();
                newEmployee.Name = employee.Name;
                newEmployee.ZipCode = employee.ZipCode;
                newEmployee.UserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

                _repo.Employee.CreateEmployee(newEmployee);
                _repo.Save();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Confirm(int accountId)
        {
            try
            {
                var account = _repo.Account.FindByCondition(a => a.Id == accountId).FirstOrDefault();
                if (account.NextPickup.Date == DateTime.Now.Date)
                {
                    account.NextPickup = account.NextPickup.AddDays(7);
                }
                else if (account.OneTimePickup.Date == DateTime.Now.Date)
                {
                    account.OneTimePickup = account.OneTimePickup.AddYears(1);
                }
                account.Balance += 20;
                _repo.Account.Update(account);
                _repo.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult FilterByDay()
        {
            ViewModel customers = new ViewModel();
            customers.Customers = _repo.Customer.GetCustomerIncludeAll();
            return View(customers);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FilterByDay(ViewModel viewModel)
        {
            var customers = _repo.Customer.GetCustomerIncludeAll();
            customers = customers.Where(a => a.Account.PickupDay == viewModel.FilterDay).ToList();
            viewModel.Customers = customers;
            return View(viewModel);
        }

        //TODO: Filter by day view/controller

        //TODO: google maps api on details of customer
    }
}