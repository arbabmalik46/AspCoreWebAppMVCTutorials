using LogInFormASPdotNetCore6.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LogInFormASPdotNetCore6.Controllers
{
    public class HomeController : Controller
    {
        /*private readonly ILogger<HomeController> _logger;


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }*/

        private readonly CodeBaseDBContext codeBaseDBContext;

        public HomeController(CodeBaseDBContext codeBaseDBContext)
        {
            this.codeBaseDBContext = codeBaseDBContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LogIn()
        {
            if (HttpContext.Session.GetString("myUser") != null)
            {
                return RedirectToAction("Dashboard");
            }
            return View();
        }

        [HttpPost]
        public IActionResult LogIn(User user)
        {
            if (ModelState.IsValid)
            {
                // Handle login logic here
                // For now, just redirect to Index on successful login
                var existingUser = codeBaseDBContext.Users.FirstOrDefault(u => u.UserEmail == user.UserEmail && u.UserPassword == user.UserPassword);
                if (existingUser != null) {
                    //return View(existingUser);
                    HttpContext.Session.SetString("myUser",user.UserName);
                    return RedirectToAction("Dashboard");
                }
                else
                {
                    ViewBag.Message = "No User Found";
                    return View("LogIn");
                }
            }
            return View(user);
        }
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return View("LogIn");
        }
        public IActionResult Dashboard()
        {
            return View();
        }
        public IActionResult SignUp()
        {
            if(HttpContext.Session.GetString("myUser")!=null)
            {
                return RedirectToAction("Dashboard");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(User user)
        {
            if (ModelState.IsValid)
            {
                if(codeBaseDBContext.Users.Where(x=>x.UserName == user.UserName || x.UserEmail == user.UserEmail).Count()>0)
                {
                    ViewBag.Message = "User Already Registered";
                }
                await codeBaseDBContext.Users.AddAsync(user);
                await codeBaseDBContext.SaveChangesAsync();
                HttpContext.Session.SetString("myUser",user.UserName);

                // TODO: persist user (e.g., save to database)
                return RedirectToAction("Dashboard");
            }
            return View(user);
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
