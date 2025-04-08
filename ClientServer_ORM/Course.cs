using System.ComponentModel.DataAnnotations;


namespace Academy_ORM
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        int Duration { get; set; }  
        public string? Description { get; set; }
    }
}
