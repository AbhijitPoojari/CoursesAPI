using CoursesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoursesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        public static List<Student> Students = new List<Student>();

        [HttpPost("AddStudent")]
        public IActionResult AddStudent([FromBody] Student newStudent)
        {
            if (newStudent == null)
                return BadRequest("Student data is required.");
            newStudent.Id = Students.Any() ? Students.Max(s => s.Id) + 1 : 1;
            Students.Add(newStudent);

            return CreatedAtAction(nameof(GetStudentById), new { id = newStudent.Id }, newStudent);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            var student = Students.FirstOrDefault(s => s.Id == id);
            return student == null ? NotFound() : Ok(student);
        }

        [HttpGet("GetStudents")]
        public IActionResult GetStudents()
        {
            return Ok(Students);
        }
    }
}
