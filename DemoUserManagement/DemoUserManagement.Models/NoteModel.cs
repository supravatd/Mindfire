﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoUserManagement.Models
{
    public class NoteModel
    {
        public int NoteId { get; set; }
        public string NoteData { get; set; }
        public int UserId { get; set; }
        public string PageName { get; set; }
        public string DateTimeAdded { get; set; }
    }
}
