using System.Diagnostics;
using AspCoreWebAppMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspCoreWebAppMVC.Controllers
{
    public class HomeControllerPrevious : Controller
    {
        private readonly ILogger<HomeControllerPrevious> _logger;

        public HomeControllerPrevious(ILogger<HomeControllerPrevious> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View("~/Views/HomeControllerPrevious/IndexHomeControllerPrevious.cshtml");
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
