using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TrashCollectorV2.Contracts;
using TrashCollectorV2.Models;

namespace TrashCollectorV2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(UserManager<IdentityUser> userManager, ILogger<HomeController> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (_userManager.Options.SignIn.RequireConfirmedAccount)
            {
                var user = _userManager.FindByIdAsync(userId).Result;
                var role = _userManager.GetRolesAsync(user).Result.FirstOrDefault();
                if (role != null)
                {
                    if (role.ToLower() == "customer")
                    {
                        return RedirectToAction("Index", "Customer");
                    }
                    if (role.ToLower() == "employee")
                    {
                        return RedirectToAction("Index", "Employee");
                    }
                    if (role.ToLower() == "admin")
                    {
                        return RedirectToAction("Index", "Employee");
                    }
                }
                return View();
            }
            return View();
        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
