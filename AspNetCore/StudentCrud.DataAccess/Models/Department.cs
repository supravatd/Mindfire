using System;
using System.Collections.Generic;

namespace StudentCrud.DataAccess.Models;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string? DepartmentName { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
