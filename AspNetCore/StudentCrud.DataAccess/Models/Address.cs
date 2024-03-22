using System;
using System.Collections.Generic;

namespace StudentCrud.DataAccess.Models;

public partial class Address
{
    public int StudentId { get; set; }

    public string? Street { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Country { get; set; }

    public virtual Student Student { get; set; } = null!;
}
