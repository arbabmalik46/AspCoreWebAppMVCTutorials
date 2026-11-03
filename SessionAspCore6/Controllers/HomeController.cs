using Microsoft.AspNetCore.Mvc;
using SessionAspCore6.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace SessionAspCore6.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Details()
        {
            if(HttpContext.Session.GetString("myName") != null)
            {
                ViewBag.Data = HttpContext.Session.GetString("myName");
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public IActionResult LogOut()
        {
            if(HttpContext.Session.GetString("myName") != null)
            {
                HttpContext.Session.Remove("myName");
                //return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Index()
        {
            HttpContext.Session.SetString("myName", "John Doe");
            return View();
        }
        public IActionResult About()
        {
            var myName = HttpContext.Session.GetString("myName");
            ViewBag.MyName = myName;
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
