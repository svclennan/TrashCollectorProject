using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using TrashCollectorV2.Contracts;
using TrashCollectorV2.Models;
using Account = TrashCollectorV2.Models.Account;
using Customer = TrashCollectorV2.Models.Customer;

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
        public ActionResult Details()
        {
            ViewModel viewModel = new ViewModel();
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var customer = _repo.Customer.FindByCondition(b => b.UserId == userId).FirstOrDefault();
                viewModel.Customer = customer;
                viewModel.Address = _repo.Address.FindByCondition(c => c.Id == customer.AddressId).FirstOrDefault();
                viewModel.Account = _repo.Account.FindByCondition(d => d.Id == customer.AccountId).FirstOrDefault();
                return View(viewModel);
            }
            catch
            {
                return View(viewModel);
            }
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
        public ActionResult Edit()
        {
            ViewModel viewModel = new ViewModel();
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var customer = _repo.Customer.FindByCondition(b => b.UserId == userId).FirstOrDefault();
                viewModel.Customer = customer;
                viewModel.Address = _repo.Address.FindByCondition(c => c.Id == customer.AddressId).FirstOrDefault();
                viewModel.Account = _repo.Account.FindByCondition(d => d.Id == customer.AccountId).FirstOrDefault();
                return View(viewModel);
            } 
            catch
            {
                return View(viewModel);
            }
        }

        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ViewModel viewModel)
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var customer = _repo.Customer.FindByCondition(b => b.UserId == userId).FirstOrDefault();
                if (customer.AccountId == null)
                {
                    Account account = new Account();
                    account.IsSuspended = viewModel.Account.IsSuspended;
                    account.OneTimePickup = viewModel.Account.OneTimePickup;
                    account.PickupDay = viewModel.Account.PickupDay;
                    DateTime NextPickup = DateTime.Now;
                    while (!NextPickup.DayOfWeek.Equals(account.PickupDay))
                    {
                        NextPickup = NextPickup.AddDays(1);
                    }
                    account.NextPickup = NextPickup;
                    account.StartDate = viewModel.Account.StartDate;
                    account.EndDate = viewModel.Account.EndDate;
                    _repo.Account.Create(account);
                    _repo.Save();

                    customer.AccountId = _repo.Account.FindByCondition(a => a.Equals(account)).FirstOrDefault().Id;
                    _repo.Customer.Update(customer);
                    _repo.Save();
                }
                else
                {
                    var account = _repo.Account.GetAccount(customer.AccountId ?? default);
                    account.IsSuspended = viewModel.Account.IsSuspended;
                    account.OneTimePickup = viewModel.Account.OneTimePickup;
                    account.PickupDay = viewModel.Account.PickupDay;
                    DateTime NextPickup = DateTime.Now;
                    while (!NextPickup.DayOfWeek.Equals(account.PickupDay))
                    {
                        NextPickup = NextPickup.AddDays(1);
                    }
                    account.NextPickup = NextPickup;
                    account.StartDate = viewModel.Account.StartDate;
                    account.EndDate = viewModel.Account.EndDate;
                    _repo.Account.Update(account);
                    _repo.Save();
                }
                return RedirectToAction(nameof(Details));
            }
            catch
            {
                return View(viewModel);
            }
        }
        public ActionResult Pay()
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var user = _repo.Customer.FindByCondition(b => b.UserId == userId).FirstOrDefault();
                var account = _repo.Account.FindByCondition(a => a.Id == user.AccountId).FirstOrDefault();

                var stripePublishKey = api_key.STRIPE_KEY();
                ViewBag.StripePublishKey = stripePublishKey;

                return View(account);
            }
            catch
            {
                return RedirectToAction(nameof(Details));
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Pay(int amount)
        {
            try
            {
                
                return RedirectToAction(nameof(Details));
            }
            catch
            {
                return View(amount);
            }
        }
        [HttpPost]
        public ActionResult Charge(string stripeEmail, string stripeToken)
        {
            var customers = new CustomerService();
            var charges = new ChargeService();

            var customer = customers.Create(new CustomerCreateOptions
            {
                Email = stripeEmail,
                Source = stripeToken
            });

            var charge = charges.Create(new ChargeCreateOptions
            {
                Amount = 2000,//charge in cents
                Description = "Sample Charge",
                Currency = "usd",
                Customer = customer.Id
            });

            var allCustomers = _repo.Customer.GetCustomerIncludeAll();
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var thisCustomer = allCustomers.Where(b => b.UserId == userId).FirstOrDefault();
            thisCustomer.Account.Balance -= 20;
            _repo.Account.Update(thisCustomer.Account);
            _repo.Save();

            return RedirectToAction(nameof(Details));
        }
    }
}