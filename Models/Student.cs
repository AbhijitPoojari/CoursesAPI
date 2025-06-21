namespace CoursesAPI.Models
{
    public class Student
    {
        public int Id { get; set; } // optional if you're assigning manually
        public string Name { get; set; }
        public string Email { get; set; }
        public int EnrolledCourseId { get; set; }
    }
}
