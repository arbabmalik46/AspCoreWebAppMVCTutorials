using Microsoft.AspNetCore.Mvc;

namespace AspCoreWebAppMVC.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
