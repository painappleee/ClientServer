using Academy_ORM;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace ClientServer_ORM_Lab2
{
    public class ProgramLab22
    {
        static void Main(string[] args)
        {
            using (ApplicationContextLab2 db = new())
            {
                //db.ClearDataBase();
                //db.SeedData();

                var courses = new List<Course>();

                // по умолчанию включена lazy loading
                courses = db.Courses.ToList();

                //eager loading
                /*courses = db.Courses
                    .Include(c => c.Teachers)
                    .Include(c => c.Students)
                    .ToList();
                */
                                    


                foreach (var course in courses)
                {
                    //explicit loading                    
                    /*db.Entry(course).Collection(c => c.Teachers).Load();
                    db.Entry(course).Collection(c => c.Students).Load();
                    */

                    Console.WriteLine($"Через курс '{course.Title}' преподаватели: ");
                    foreach (var teacher in course.Teachers)
                    {
                        Console.WriteLine($"{teacher.LastName} ");

                    }

                    Console.WriteLine("Взаимодействуют со студентами ");
                    foreach (var student in course.Students)
                    {
                        Console.WriteLine($"{student.LastName} ");

                    }
                    Console.WriteLine();

                }            

            }
        }
    }
    
}
