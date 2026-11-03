using ASPCoreAPIWithCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace ASPCoreAPIWithCRUD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly CodeBaseDBContext _codeBaseDBContext;
        public StudentController(CodeBaseDBContext codeBaseDB)
        {
            _codeBaseDBContext = codeBaseDB;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _codeBaseDBContext.Students.ToListAsync();
            return Ok(students);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var student = await _codeBaseDBContext.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }
        [HttpPost]
        public async Task<IActionResult> CreateStudent(Student std)
        {
            if(std!= null)
            {
                await _codeBaseDBContext.Students.AddAsync(std);
                await _codeBaseDBContext.SaveChangesAsync();
                return Ok("Object Created");
            }
            return Ok("No Content");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, Student std)
        {
            try
            {
                if (id > 0 && std != null)
                {
                    _codeBaseDBContext.Entry(std).State = EntityState.Modified;
                    await _codeBaseDBContext.SaveChangesAsync();
                    return Ok("Data Modified");
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }   
        }
        [HttpDelete("{StudentId}")]
        public async Task<IActionResult> DeleteRecord(int StudentId)
        {
            try
            {
                if (StudentId > 0)
                {
                    var recordToDelete = await _codeBaseDBContext.Students.FindAsync(StudentId);
                    _codeBaseDBContext.Students.Remove(recordToDelete);
                    await _codeBaseDBContext.SaveChangesAsync();
                    return Ok("Record Deleted");
                }
                else
                {
                    return NotFound("No record Found");
                }
            }
            catch (Exception ex)
            {
                return UnprocessableEntity("Error while deleting");
            }
        }
    }
}
