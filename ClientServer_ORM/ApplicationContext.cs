using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Academy_ORM
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<Course> Courses { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                         .AddJsonFile("appsettings.json")
                         .SetBasePath(Directory.GetCurrentDirectory())
                         .Build();

            optionsBuilder.UseSqlite(config.GetConnectionString("DefaultConnection"));
        }

        public void SeedData()
        {
            if (!Courses.Any())
            {
                Course course1 = new Course { Title = "Математика" };
                Course course2 = new Course { Title= "Физика" };
                Course course3 = new Course { Title= "История" };

                Courses.Add(course1);
                Courses.Add(course2);
                Courses.Add(course3);

               SaveChanges();
            }
        }

        public void CreateCourse(string title)
        {
            Courses.Add(new Course { Title =  title });
            SaveChanges();
        }

        public void UpdateCourse(int courseId, string newTitle)
        {
            var course = Courses.Find(courseId);
            if (course != null)
            {
                course.Title = newTitle;
                SaveChanges();
            }
        }

        public void DeleteCourse(int courseId)
        {
            var course = Courses.Find(courseId);
            if (course != null)
            {
                Courses.Remove(course);
                SaveChanges();
            }
        }

        public void DeleteAllCourses()
        {
            foreach (var course in Courses)
            {
                Courses.Remove(course);
            }
            SaveChanges();
        }
    }
}
