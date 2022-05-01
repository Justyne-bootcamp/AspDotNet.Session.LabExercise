using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Session.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Session.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult Index()
        {
            if (HttpContext.Session.GetString("username") != null)
            {
                return RedirectToAction("Index", "Toy");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if(username.Equals("user") && password.Equals("123")){
                HttpContext.Session.SetString("username", username);
                return RedirectToAction("Index", "Toy");
            }
            ViewBag.errorMsg = "Invalid Account";
            return View("Index");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            HttpContext.Session.Remove("cart");
            return RedirectToAction("Index");
        }
    }
}
