using CodeFirstASPCore6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CodeFirstASPCore6.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        public readonly StudentContext _studentContext;
        public HomeController(StudentContext studentContext)
        {
            this._studentContext = studentContext;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _studentContext.Students.ToListAsync();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Student std)
        {
            await _studentContext.Students.AddAsync(std);
            await _studentContext.SaveChangesAsync();
            TempData["CreatedMessage"] = "Student created successfully.";
            return RedirectToAction("Index");
            //return View();
        }
        public async Task<IActionResult> Details(int id)
        {
            var model = await _studentContext.Students.FirstOrDefaultAsync(x => x.ID == id);
            if (model == null || _studentContext.Students.Count() == 0)
            {
                return NotFound();
            }
            return View(model);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _studentContext.Students.FirstOrDefaultAsync(x => x.ID == id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var form = Request.Form;
            var model = await _studentContext.Students.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            _studentContext.Students.Remove(model);
            await _studentContext.SaveChangesAsync();
            TempData["DeleteMessage"] = "Student deleted successfully.";
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || _studentContext.Students.Count() == 0)
            {
                return NotFound();
            }
            var model = await _studentContext.Students.FindAsync(id);
            if(model == null)
            {
                TempData["NotFoundMessage"] = "Student not found.";
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Student std)
        {
            if (ModelState.IsValid)
            {
                _studentContext.Update(std);
                await _studentContext.SaveChangesAsync();
                TempData["UpdateMessage"] = "Student updated successfully.";
                return RedirectToAction("Index");
            }
            return View(std);
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
