using Microsoft.AspNetCore.Mvc;

namespace InstallingFrontEndLibraries.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
