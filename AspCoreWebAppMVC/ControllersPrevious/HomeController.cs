using Microsoft.AspNetCore.Mvc;

namespace AspCoreWebAppMVC.ControllersPrevious;

public class HomeController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}