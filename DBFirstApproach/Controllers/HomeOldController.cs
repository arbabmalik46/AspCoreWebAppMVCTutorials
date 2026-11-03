using DBFirstApproach.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DBFirstApproach.Controllers
{
    public class HomeOldController : Controller
    {
        private readonly ILogger<HomeOldController> _logger;
        private readonly CodeBaseDBContext context;
        public HomeOldController(ILogger<HomeOldController> logger, CodeBaseDBContext ctx)
        {
            _logger = logger;
            context = ctx;
        }

        public IActionResult Index()
        {
            return View(context.Students.ToList());
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
