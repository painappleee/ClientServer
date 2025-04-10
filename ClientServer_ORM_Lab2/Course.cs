using ClientServer_ORM_Lab2;
using System.ComponentModel.DataAnnotations;


namespace Academy_ORM
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        public int Duration { get; set; }  
        public string? Description { get; set; }

        public virtual ICollection<Student>? Students { get; set; } = new List<Student>();
        public virtual ICollection<Teacher>? Teachers { get; set; } = new List<Teacher>();

    }
}
