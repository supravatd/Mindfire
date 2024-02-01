using OfficeOpenXml;
using StudentLayer.DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace StudentLayer.Business
{
    public class BusinessLayer
    {
        public static List<StudentModel> DisplayStudent(string fileName)
        {
            return DAL.DAL.DisplayStudent(fileName);
        }

        public static bool InsertStudent(StudentModel student1, string fileName)
        {
            return DAL.DAL.InsertStudent(student1, fileName);
        }

        public static bool UpdateStudent(int studentId, StudentModel studentInput, string fileName)
        {
            return DAL.DAL.UpdateStudent(studentId, studentInput, fileName);
        }

        public static bool DeleteStudent(int studentId, string fileName)
        {
            return DAL.DAL.DeleteStudent(studentId, fileName);
        }

        public static List<StudentModel> SearchStudent(string searchString)
        {
            return DAL.DAL.SearchStudent(searchString);
        }

        public static List<TeacherModel> DisplayTeacher(string fileName)
        {
            return DAL.DAL.DisplayTeacher(fileName);
        }

        public static bool InsertTeacher(TeacherModel teacher1, string fileName)
        {
            return DAL.DAL.InsertTeacher(teacher1, fileName);
        }

        public static bool UpdateTeacher(int teacherId, TeacherModel teacher, string fileName)
        {
            return DAL.DAL.UpdateTeacher(teacherId, teacher, fileName);
        }

        public static bool DeleteTeacher(int teacherId, string fileName)
        {
            return DAL.DAL.DeleteTeacher(teacherId, fileName);
        }

        public static List<SemesterModel> DisplaySemesters(string fileName)
        {
            List<SemesterModel> allSemesters = DAL.DAL.DisplaySemesters(fileName);
            return allSemesters;
        }

        public static bool InsertSemester(string semesterName, string fileName)
        {
            bool res = DAL.DAL.InsertSemester(semesterName, fileName);
            return res;
        }

        public static bool UpdateSemester(int semesterId, string newSemesterName, string fileName)
        {
            return DAL.DAL.UpdateSemester(semesterId, newSemesterName, fileName);
        }

        public static bool DeleteSemester(int semesterId, string fileName)
        {
            return DAL.DAL.DeleteSemester(semesterId, fileName);
        }

        public static List<CourseModel> DisplayCourse(string fileName)
        {
            return DAL.DAL.GetCourses(fileName);
        }

        public static bool InsertCourse(string courseName, string fileName)
        {
            return DAL.DAL.InsertCourse(courseName, fileName);
        }

        public static bool UpdateCourse(int courseId, string newCourseName, string fileName)
        {
            return DAL.DAL.UpdateCourse(courseId, newCourseName, fileName);
        }

        public static bool DeleteCourse(int courseId, string fileName)
        {
            return DAL.DAL.DeleteCourse(courseId, fileName);
        }

        public static List<AddressModel> DisplayAddress(string fileName)
        {
            return DAL.DAL.DisplayAddress(fileName);
        }

        public static bool InsertAddress(AddressModel address, string fileName)
        {
            return DAL.DAL.InsertAddress(address, fileName);
        }

        public static bool UpdateAddress(int studentId, AddressModel address, string fileName)
        {
            return DAL.DAL.UpdateAddress(studentId, address, fileName);
        }

        public static bool DeleteAddress(int studentId, string fileName)
        {
            return DAL.DAL.DeleteAddress(studentId, fileName);
        }

        public static void ExportDataToExcel<T>(List<T> dataList, string fileName)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            FileInfo fileInfo = new FileInfo(fileName);
            using (ExcelPackage excelPackage = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Count > 0 ? excelPackage.Workbook.Worksheets[0] : excelPackage.Workbook.Worksheets.Add("Sheet1");
                var properties = dataList[0].GetType().GetProperties();
                for (int j = 0; j < properties.Length; j++)
                {
                    worksheet.Cells[1, j + 1].Value = properties[j].Name;
                    worksheet.Cells[1, j + 1].Style.Font.Bold = true;
                }

                worksheet.Cells[1, properties.Length + 1].Value = "Date and Time";
                worksheet.Cells[1, properties.Length + 1].Style.Font.Bold = true;

                for (int i = 0; i < dataList.Count; i++)
                {
                    properties = dataList[i].GetType().GetProperties();
                    for (int j = 0; j < properties.Length; j++)
                    {
                        worksheet.Cells[i + 2, j + 1].Value = properties[j].GetValue(dataList[i]);
                    }
                    worksheet.Cells[i + 2, properties.Length + 1].Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                }

                excelPackage.Save();
            }
        }

        public static void ExportDataToCsv<T>(List<T> data, string fileName)
        {
            if (data == null || data.Count == 0)
            {
                Console.WriteLine("No data to export.");
                return;
            }

            var csvContent = new StringBuilder();
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                csvContent.Append(property.Name).Append(",");
            }
            csvContent.AppendLine();

            foreach (var item in data)
            {
                foreach (var property in properties)
                {
                    var value = property.GetValue(item);
                    csvContent.Append(value).Append(",");
                }
                csvContent.AppendLine();
            }

            File.WriteAllText(fileName, csvContent.ToString());
        }
    }
}
