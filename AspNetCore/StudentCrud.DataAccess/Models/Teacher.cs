using System;
using System.Collections.Generic;

namespace StudentCrud.DataAccess.Models;

public partial class Teacher
{
    public int TeacherId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int? SemesterId { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual Semester? Semester { get; set; }
}
