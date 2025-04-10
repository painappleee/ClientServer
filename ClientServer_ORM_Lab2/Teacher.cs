using Academy_ORM;
using System.ComponentModel.DataAnnotations;


namespace ClientServer_ORM_Lab2
{
    public class Teacher
    {
        public int Id { get; set; }

        [Required]
        public string LastName { get; set; }

        public string FirstName { get; set; }
        public int Age { get; set; }  

        public int Experience {  get; set; }

        public virtual ICollection<Course>? Courses { get; set; } = new List<Course>();

    }
}
