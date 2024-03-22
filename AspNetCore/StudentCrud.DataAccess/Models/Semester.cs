using System;
using System.Collections.Generic;

namespace StudentCrud.DataAccess.Models;

public partial class Semester
{
    public int SemesterId { get; set; }

    public string? SemesterName { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
