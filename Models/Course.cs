namespace CoursesAPI.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string StartDate { get; set; }
        public bool SoldOut { get; set; }
        public string ImageUrl { get; set; }
    }

}
