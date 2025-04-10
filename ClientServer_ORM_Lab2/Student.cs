﻿using System.ComponentModel.DataAnnotations;
using System.Diagnostics;


namespace Academy_ORM
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        public string LastName { get; set; }

        public string FirstName { get; set; }
        public int Age { get; set; }
        public virtual ICollection<Course>? Courses { get; set; } = new List<Course>();




    }
}
