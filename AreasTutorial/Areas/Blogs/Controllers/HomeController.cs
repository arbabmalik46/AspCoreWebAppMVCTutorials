using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace AreasTutorial.Areas.Blogs.Controllers
{
    public class HomeController : Controller
    {
        [Area("Blogs")]
        public IActionResult Index()
        {
            HMACSHA256 hMACSHA256 = new HMACSHA256();
            return View();
        }
    }
}
