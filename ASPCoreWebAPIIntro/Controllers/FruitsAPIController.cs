using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPCoreWebAPIIntro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FruitsAPIController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetFruits()
        {
            var fruits = new List<string> { "Apple", "Banana", "Cherry" };
            return Ok(fruits);
        }
        [HttpGet("{id}")]
        public IActionResult GetFruits(int id)
        {
            var fruit = new string("Apple"); // Replace with actual fruit retrieval logic
            return Ok(fruit);
        }
    }
}
