﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLayers.Utils
{
    public class TeacherInsert
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int SemesterId { get; set; }
        public int TeacherId { get; set; }
    }
}
