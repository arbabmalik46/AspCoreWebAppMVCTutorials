using Microsoft.AspNetCore.Mvc;
using ModelViewImport.Models;

namespace ModelViewImport.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            List<Student> students = new List<Student>()
            {
                new Student(){Id=1,Name="John",Description="John is a student."},
                new Student(){Id=2,Name="Jane",Description="Jane is a student."},
                new Student(){Id=3,Name="Bob",Description="Bob is a student."},
                new Student(){Id=4,Name="Alice",Description="Alice is a student."},
                new Student(){Id=5,Name="Tom",Description="Tom is a student."}
            };
            
            return View(students);
        }
        public IActionResult Contact()
        {
            List<Student> students = new List<Student>()
            {
                new Student(){Id=1,Name="John",Description="John is a student."},
                new Student(){Id=2,Name="Jane",Description="Jane is a student."},
                new Student(){Id=3,Name="Bob",Description="Bob is a student."},
                new Student(){Id=4,Name="Alice",Description="Alice is a student."},
                new Student(){Id=5,Name="Tom",Description="Tom is a student."}
            };

            return View(students);
        }
        public IActionResult AboutUs()
        {
            List<Student> students = new List<Student>()
            {
                new Student(){Id=1,Name="John",Description="John is a student."},
                new Student(){Id=2,Name="Jane",Description="Jane is a student."},
                new Student(){Id=3,Name="Bob",Description="Bob is a student."},
                new Student(){Id=4,Name="Alice",Description="Alice is a student."},
                new Student(){Id=5,Name="Tom",Description="Tom is a student."}
            };

            return View(students);
        }
    }
}
