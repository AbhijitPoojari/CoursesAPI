using CoursesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoursesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        public static List<Course> Courses = new List<Course>
        {
            new Course
            {
                Id = 1,
                Title = "Introduction to Web Development",
                Description = "Learn the basics of HTML, CSS, and JavaScript to start building your own websites from scratch.",
                Price = 4999,
                StartDate = "July 1, 2025",
                SoldOut = true,
                ImageUrl = "/images/web-dev.jpg"
            },
            new Course
            {
                Id = 2,
                Title = "Advanced Angular Mastery",
                Description = "Build scalable, production-grade Angular applications using modern techniques and best practices.",
                Price = 7999,
                StartDate = "July 15, 2025",
                SoldOut = false,
                ImageUrl = "/images/web-dev.jpg"
            }
        };

        [HttpGet("GetCourses")]
        public IActionResult GetCourses()
        {
            return Ok(Courses);
        }

        [HttpGet("GetCourse/{id}")]
        public IActionResult GetCourseById(int id)
        {
            var course = Courses.FirstOrDefault(c => c.Id == id);
            if (course == null)
            {
                return NotFound($"No course found with ID {id}");
            }
            return Ok(course);
        }


        [HttpPost("AddCourse")]
        public IActionResult AddCourse([FromBody] Course newCourse)
        {
            if (newCourse == null)
                return BadRequest("Course data is required.");

            // Simulate ID assignment
            newCourse.Id = Courses.Any() ? Courses.Max(c => c.Id) + 1 : 1;

            Courses.Add(newCourse);
            return CreatedAtAction(nameof(GetCourses), new { id = newCourse.Id }, newCourse);
        }
    }
}
