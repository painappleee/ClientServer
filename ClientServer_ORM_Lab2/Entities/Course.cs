using System.ComponentModel.DataAnnotations;


namespace ClientServer_ORM_Lab2.Entities
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
