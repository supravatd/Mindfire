using System;
using System.Collections.Generic;

namespace StudentCrud.DataAccess.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Gender { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public string? Position { get; set; }

    public decimal? Salary { get; set; }

    public DateOnly? HireDate { get; set; }

    public string? EmailAddress { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? ZipCode { get; set; }

    public string? Country { get; set; }

    public int? DepartmentId { get; set; }

    public virtual Department? Department { get; set; }
}
