using ClientServer_ORM_Lab2;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Academy_ORM
{
    public class ApplicationContextLab2 : DbContext
    {
        public ApplicationContextLab2()
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreates();
        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }


        // подключение к базе данных
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                         .AddJsonFile("appsettings.json")
                         .SetBasePath(Directory.GetCurrentDirectory())
                         .Build();

            optionsBuilder.UseSqlite(config.GetConnectionString("DefaultConnection"));

            //для включения lazy loading
            optionsBuilder.UseLazyLoadingProxies().UseSqlite(config.GetConnectionString("DefaultConnection"));

            string logFilePath = "logs.txt";

            optionsBuilder
                .UseSqlite(config.GetConnectionString("DefaultConnection"))
                .LogTo(
                    message => File.AppendAllText(logFilePath, $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} {message}{Environment.NewLine}"),
                    LogLevel.Information) 
                .EnableSensitiveDataLogging();
        } 

        // настройка связей между таблицами
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Настройка связи многие-ко-многим между Course и Teacher
            modelBuilder.Entity<Course>()
                .HasMany(c => c.Teachers)
                .WithMany(t => t.Courses)
                .UsingEntity<Dictionary<string, object>>(
                    "CourseTeacher",
                    j => j.HasOne<Teacher>().WithMany().HasForeignKey("TeacherId"),
                    j => j.HasOne<Course>().WithMany().HasForeignKey("CourseId"),
                    j => j.ToTable("CourseTeachers"));

            // Настройка связи многие-ко-многим между Course и Student
            modelBuilder.Entity<Course>()
                .HasMany(c => c.Students)
                .WithMany(s => s.Courses)
                .UsingEntity<Dictionary<string, object>>(
                    "CourseStudent",
                    j => j.HasOne<Student>().WithMany().HasForeignKey("StudentId"),
                    j => j.HasOne<Course>().WithMany().HasForeignKey("CourseId"),
                    j => j.ToTable("CourseStudents"));
        }

        // заполнение данных
        public void SeedData()
        {

            if (!Courses.Any() && !Students.Any() && !Teachers.Any())
            {
                Student student1 = new Student { FirstName = "Инна", LastName = "Иванова", Age = 20 };
                Student student2 = new Student { FirstName = "Олег", LastName = "Григорьев", Age = 25 };
                Student student3 = new Student { FirstName = "Петр", LastName = "Афанасьев", Age = 35 };

                Students.Add(student1);
                Students.Add(student2);
                Students.Add(student3);


                Teacher teacher1 = new Teacher { FirstName = "Василий", LastName = "Андреев", Age = 40 };
                Teacher teacher2 = new Teacher { FirstName = "Оксана", LastName = "Юрьева", Age = 35 };
                Teacher teacher3 = new Teacher { FirstName = "Григорий", LastName = "Павлов", Age = 45 };

                Teachers.Add(teacher1);
                Teachers.Add(teacher2);
                Teachers.Add(teacher3);

                Course course1 = new Course { Title = "Математика" };
                Course course2 = new Course { Title = "Физика" };
                Course course3 = new Course { Title = "История" };

                course1.Teachers = new List<Teacher> { teacher1, teacher2 };
                course2.Teachers = new List<Teacher> { teacher1 };
                course3.Teachers = new List<Teacher> { teacher2, teacher3 };

                course1.Students = new List<Student> { student1, student2 };
                course2.Students = new List<Student> { student2, student3};
                course3.Students = new List<Student> { student1, student2, student3 };

                Courses.Add(course1);
                Courses.Add(course2);
                Courses.Add(course3);

                SaveChanges();
            }
        }

        // работа с курсами
        public void CreateCourse(string title)
        {
            Courses.Add(new Course { Title = title });
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

        // работа со студентами
        public void CreateStudent(string firstName, string lastName)
        {
            Students.Add(new Student { FirstName = firstName, LastName = lastName });
            SaveChanges();
        }

        public void UpdateStudent(int studentId, string newLastName)
        {
            var student = Students.Find(studentId);
            if (student != null)
            {
                student.LastName = newLastName;
                SaveChanges();
            }
        }

        public void DeleteStudent(int studentId)
        {
            var student = Students.Find(studentId);
            if (student != null)
            {
                Students.Remove(student);
                SaveChanges();
            }
        }

        // работа с учителями

        public void CreateTeacher(string firstName, string lastName)
        {
            Teachers.Add(new Teacher { FirstName = firstName, LastName = lastName });
            SaveChanges();
        }

        public void UpdateTeacher(int teacherId, string newLastName)
        {
            var teacher = Teachers.Find(teacherId);
            if (teacher != null)
            {
                teacher.LastName = newLastName;
                SaveChanges();
            }
        }

        public void DeleteTeacher(int teacherId)
        {
            var teacher = Teachers.Find(teacherId);
            if (teacher != null)
            {
                Teachers.Remove(teacher);
                SaveChanges();
            }
        }

       
        // очистка данных
        public void DeleteAllCourses()
        {
            foreach (var course in Courses)
            {
                Courses.Remove(course);
            }
            SaveChanges();
        }

        public void DeleteAllStudents()
        {
            foreach (var student in Students)
            {
                Students.Remove(student);
            }
            SaveChanges();
        }

        public void DeleteAllTeachers()
        {
            foreach (var teacher in Teachers)
            {
                Teachers.Remove(teacher);
            }
            SaveChanges();
        }

        public void ClearDataBase()
        {
            DeleteAllCourses();
            DeleteAllStudents();
            DeleteAllTeachers();
        }

    }
}
