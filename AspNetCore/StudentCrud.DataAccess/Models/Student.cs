using System;
using System.Collections.Generic;

namespace StudentCrud.DataAccess.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int? SemesterId { get; set; }

    public virtual Address? Address { get; set; }

    public virtual Semester? Semester { get; set; }

    public virtual ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
}
