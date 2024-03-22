﻿using System;
using System.Collections.Generic;

namespace StudentCrud.DataAccess.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public string? CourseName { get; set; }

    public int? TeacherId { get; set; }

    public int? SemesterId { get; set; }

    public virtual Semester? Semester { get; set; }

    public virtual ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();

    public virtual Teacher? Teacher { get; set; }
}
