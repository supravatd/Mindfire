using System;
using System.Collections.Generic;

namespace StudentCrud.DataAccess.Models;

public partial class Note
{
    public int NoteId { get; set; }

    public string? NoteData { get; set; }

    public string? UserId { get; set; }

    public string? PageName { get; set; }

    public DateTime? DateTimeAdded { get; set; }
}
