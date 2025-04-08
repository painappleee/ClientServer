namespace Academy_ORM
{
    internal class ProgramLab21
    {
        static void Main(string[] args)
        {
           using (ApplicationContext db = new())
           {
                db.DeleteAllCourses();
                db.SeedData();

                Console.WriteLine("----до----");

                var courses = db.Courses.ToList();

                foreach (var course in courses)
                {
                    Console.WriteLine(course.Title);
                }

                db.CreateCourse("Литература");


                var courseToUpdate = courses.FirstOrDefault();
                if (courseToUpdate != null)
                {
                    db.UpdateCourse(courseToUpdate.Id, "География");
                }

                var courseToDelete = courses.Last();
                if (courseToDelete != null)
                {
                    db.DeleteCourse(courseToDelete.Id);
                }

                Console.WriteLine("----после----");

                courses = db.Courses.ToList();

                foreach (var course in courses)
                {
                    Console.WriteLine(course.Title);
                }

            }
        } 
    }
}
