using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

namespace AspCoreWebAppMVC.ControllersPrevious
{
    [Route("[controller]/[action]")]
    public class UserController : Controller
    {
        [Route("")]
        //[Route("Index")]
        //[Route("/index")]
        //[Route("~/")]
        //[Route("~/Home")]
        public IActionResult Index()
        {
            return View();
        }

        //[Route("[action]")]
        public IActionResult Data()
        {
            return View("~/Views/User/Index.cshtml");
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}

        //[Route("Home/About")]
        //[Route("/About")]
        //[Route("[action]")]
        public IActionResult About()
        {
            return View("~/Views/User/About.cshtml");
        }
        //[Route("/Details")]
        //[Route("/Details/{id?}")]
        //[Route("[action]")]
        public string Details(string? id)
        {
            if(id is null)
            {
                return "Enter some ID please!";
            }
            if(id.Contains("."))
            {
                return "Invalid ID";
            }
            return id;
        }
    }
}
