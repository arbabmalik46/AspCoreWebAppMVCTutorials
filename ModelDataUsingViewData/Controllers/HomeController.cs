using Microsoft.AspNetCore.Mvc;
using ModelDataUsingViewData.Models;
using System.Diagnostics;

namespace ModelDataUsingViewData.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Employee emp = new Employee
            {
                Id = 101,
                Name = "John Doe",
                Description = "A skilled software developer with expertise in ASP.NET Core.",
                Department = "IT",
                Salary = 75000.00m,
                Sale = 150000.00m,
                Age = 30,
                Experience = 8
            };
            ViewData["Employee"] = emp;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            Employee emp = new Employee
            {
                Id = 102,
                Name = "Jane Smith",
                Description = "An experienced project manager with a track record of successful projects.",
                Department = "Management",
                Salary = 90000.00m,
                Sale = 200000.00m,
                Age = 35,
                Experience = 12
            };
            return View(emp);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
