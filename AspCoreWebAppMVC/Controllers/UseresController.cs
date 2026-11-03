using AspCoreWebAppMVC.Models;
using AspCoreWebAppMVC.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace AspCoreWebAppMVC.Controllers
{
    public class ExampleDataClass
    {
        public int Age { get; set; } = 26;
        public string Name { get; set; } = "Arbab Malik";
    }
    public class UseresController : Controller
    {
        private readonly ILogger<UseresController> _logger;
        private readonly IStudent _studentRepository;

        public UseresController(ILogger<UseresController> logger, IStudent student)
        {
            _logger = logger;
            _studentRepository = student;
        }
        public UserData GetUserDataByID(int id)
        {
            return _studentRepository.GetUserByID(id);
        }

        public List<UserData> GetAllUsers()
        {
            return _studentRepository.GetUsers();
        }

        RegionInfo region = new RegionInfo("US");
        // GET: UserController
        public ActionResult Index()
        {
            ViewData["Region"] = region;
            ViewData["Data"] = new ExampleDataClass();
            ViewData["Name"] = "Arbab Malik";
            ViewData["Title"] = "Index Page of UserController";
            return View();
        }

        // GET: UserController/Details/5
        public ViewResult DetailsUsers(int? id)
        {
            ViewBag.Name = "Malik Arbab Munawar";
            ViewBag.Title = "DetailsUsers view of UseresController";
            return View();
        }
        public ViewResult Contact()
        {
            TempData["Title"] = "Contact View of UseresController";
            TempData["Owner"] = "Arbab Malik";
            return View();
        }
        // GET: UserController/Create
        public ContentResult Create()
        {
            return Content("This is a simple Text for Create action method of UserController");
        }
        public ActionResult TempDataMethod()
        {
            TempData["Message"] = "Hello World";
            return View("~/Views/Useres/TempDataMethod.cshtml");
        }
        [Route("/ModelSetMethod")]
        public ActionResult ModelSetMethod()
        {
            return View("~/Views/Useres/ModelSetMethodView.cshtml", new UserData { UserName = "Arbab Malik", UserAge = 26, UserEmail = "arbab.malik@example.com", Password = "securepassword" });
        }
        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public JsonResult Edit(int id)
        {
            string name = "Arbab Malik";
            return Json(new { name});
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public EmptyResult Delete()
        {
            return new EmptyResult();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
