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
    public class CustomerController : Controller
    {
        private readonly IRepositoryWrapper _repo;
        public CustomerController(IRepositoryWrapper repo)
        {
            _repo = repo;
        }
        // GET: Customer
        public ActionResult Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (_repo.Customer.FindByCondition(a => a.UserId == userId).Any())
            {
                ViewModel viewModel = new ViewModel();
                var customer = _repo.Customer.FindByCondition(b => b.UserId == userId).FirstOrDefault();
                viewModel.Customer = customer;
                viewModel.Address = _repo.Address.FindByCondition(c => c.Id == customer.AddressId).FirstOrDefault();
                viewModel.Account = _repo.Account.FindByCondition(d => d.Id == customer.AccountId).FirstOrDefault();
                return View(viewModel);
            }
            else
            {
                return RedirectToAction("Create");
            }
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            try
            {
                _repo.Address.CreateAddress(customer.Address);
                _repo.Save();

                var newCustomer = new Customer();
                newCustomer.AddressId = _repo.Address.FindByCondition(a => a.Equals(customer.Address)).FirstOrDefault().Id;
                newCustomer.Name = customer.Name;
                newCustomer.UserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                _repo.Customer.CreateCustomer(newCustomer);
                _repo.Save();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customer/Edit/5
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

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer/Delete/5
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