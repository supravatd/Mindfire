using StudentLayer.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLayer.Models.ModelView
{
    public class ExportDataModel
    {
        public string SemesterName { get; set; }
        public string TeacherName { get; set; }
        public string StudentName { get; set; }
        public string CourseName { get; set; }
        public int StudentId { get; set; }

    }
}