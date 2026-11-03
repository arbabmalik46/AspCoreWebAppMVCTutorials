using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TagHelpersDemo.Models;

namespace TagHelpersDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public string Index(Employee emp)
        {
            if(ModelState.IsValid)
            {
                return $"Name: {emp.Name}";
            }
            return "Name is mandatory";
        }
        //[Route("")]
        //[HttpPost]
        //public string Index(Employee emp)
        //{
        //    return $"Name: {emp.Name}, Age: {emp.Age}, Gender: {emp.EmployeeGender}, Job Description: {emp.Description}, Married: {emp.Married}, Salary: {emp.Salary}";
        //}
        //[HttpPost]
        //public IActionResult Index(JsonContent json)
        //{
        //    return Json(json);
        //}
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Contact()
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
