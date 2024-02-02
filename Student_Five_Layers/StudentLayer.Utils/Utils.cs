namespace StudentLayer.Utils
{
    public static class Utils
    {
        public enum CrudOp
        {
            View_All_Student = 1,
            Insert_Student,
            Update_Student,
            Delete_Student,
            Assign_Student_To_Course,
            Search_Student,
            View_All_Teacher,
            Insert_Teacher,
            Update_Teacher,
            Delete_Teacher,
            View_All_Semester,
            Insert_Semester,
            Update_Semester,
            Delete_Semester,
            View_All_Course,
            Insert_Course,
            Update_Course,
            Delete_Course,
            View_All_Address,
            Insert_Address,
            Update_Address,
            Delete_Address,
            Export_Data,
            Excel_Semester,
            Exit,
        }
        public enum ExportFormat
        {
            Excel,
            Csv,
            Both
        }

        public enum Table
        {
            Student,
            Teacher,
            Semester,
            Course,
            Address,
        }
    }
}
