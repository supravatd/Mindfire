using System;
using System.Collections.Generic;

namespace StudentCrud.DataAccess.Models;

public partial class ErrorLog
{
    public int ErrorId { get; set; }

    public string? ErrorMessage { get; set; }

    public DateTime? LogTime { get; set; }
}
