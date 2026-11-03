using APIImplementation.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Serialization;

namespace APIImplementation.Controllers
{
    public class StudentController : Controller
    {
        public string URL = "https://localhost:5001/api/Student";
        public readonly HttpClient _httpClient = new HttpClient();
        [HttpGet]
        public IActionResult Index()
        {
            List<Student> students = new List<Student>();
            //students = _httpClient.GetFromJsonAsync<List<Student>>(URL).Result;
            HttpResponseMessage httpResponseMessage = _httpClient.GetAsync(URL).Result;
            if(httpResponseMessage.IsSuccessStatusCode)
            {
                string result = httpResponseMessage.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<List<Student>>(result);
                if(data!=null)
                {
                    students = data;
                }
            }

            return View(students);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student std)
        {
            var json = JsonConvert.SerializeObject(std);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponse = await _httpClient.PostAsync(URL, content);
            if(httpResponse.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError("", "Error Creating Student. Try Again");
            }
            return View(std);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var students = new List<Student>();
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync($"{URL}/{id}");
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                string result = await httpResponseMessage.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<Student>(result);
                if (data != null)
                {
                    return View(data);
                }
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Student std)
        {
            try
            {
                string data = JsonConvert.SerializeObject(std);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                // Ensure the request goes to /api/Student/{id}
                HttpResponseMessage response = await _httpClient.PutAsync($"{URL}/{std.StudentId}", content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }

                // Read error details (if any) to show helpful message
                var error = await response.Content.ReadAsStringAsync();
                ModelState.AddModelError("", $"Error updating student: {response.StatusCode} - {error}");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Exception: {ex.Message}");
            }

            // If we get here something failed — re-render the view with the entered data and errors
            return View(std);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var student = new Student();
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync($"{URL}/{id}");
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                string result = await httpResponseMessage.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<Student>(result);
                if (data != null)
                {
                    student = data;
                }
            }
            return View(student);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var studentModel = new Student();
            HttpResponseMessage httpResponse = await _httpClient.GetAsync($"{URL}/{id}");
            if(httpResponse.IsSuccessStatusCode)
            {
                string result = await httpResponse.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<Student>(result);
                if (data != null)
                {
                    studentModel = data;
                    httpResponse = await _httpClient.DeleteAsync($"{URL}/{id}");
                    if(httpResponse.IsSuccessStatusCode)
                    {
                        ViewData["alert-Message"] = "Data Deleted";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        var error = await httpResponse.Content.ReadAsStringAsync();
                        ModelState.AddModelError("", $"Error deleting student: {httpResponse.StatusCode} - {error}");
                    }
                }
                else
                {
                    ViewData["alert-Message"] = "No Data is available";
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewData["alert-Message"] = "No Data is available";
            return RedirectToAction(nameof(Index));
        }
        //[HttpPost]
        //public async Task<IActionResult> Create(Student student)
        //{
        //    try
        //    {
        //        var json = JsonConvert.SerializeObject(student);
        //        var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
        //        HttpResponseMessage httpResponseMessage = await _httpClient.PostAsync(URL, content);

        //        if(httpResponseMessage.IsSuccessStatusCode)
        //        {
        //            return RedirectToAction(nameof(Index));
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "Error creating student. Please try again.");
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        ModelState.AddModelError("", $"Error: {ex.Message}");
        //    }

        //    return View(student);
        //}
    }
}
