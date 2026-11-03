using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ViewModelAspCore6.Models;

namespace ViewModelAspCore6.Controllers
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
            var modelViewObject = new TeacherStudentAggregate
            {
                Students = new List<Student>
                {
                    new Student { Id = 1, Name = "Alice" },
                    new Student { Id = 2, Name = "Bob" }
                },
                Teachers = new List<Teacher>
                {
                    new Teacher { Id = 1, Name = "Mr. Smith" },
                    new Teacher { Id = 2, Name = "Ms. Johnson" }
                }
            };
            return View(modelViewObject);
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
