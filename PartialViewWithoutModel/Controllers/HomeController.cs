using Microsoft.AspNetCore.Mvc;
using PartialViewWithoutModel.Models;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace PartialViewWithoutModel.Controllers
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
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Products()
        {
            List<Products> products = new List<Products>
            {
                new Products { Id = 1, Name = "Product 1", Price = 10.99m, Description = "Description for Product 1", ImageUrl = "/images/img1.png" },
                new Products { Id = 2, Name = "Product 2", Price = 19.99m, Description = "Description for Product 2", ImageUrl = "/images/img2.png" },
                new Products { Id = 3, Name = "Product 3", Price = 5.99m, Description = "Description for Product 3", ImageUrl = "/images/img3.png" }
            };
            return View(products );
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
