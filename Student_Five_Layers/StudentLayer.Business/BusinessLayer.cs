using OfficeOpenXml;
using StudentLayer.DAL;
using StudentLayer.Models.ModelView;
using StudentLayer.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        public static bool UpdateStudent(StudentModel studentInput, string fileName)
        {
            return DAL.DAL.UpdateStudent(studentInput, fileName);
        }

        public static bool DeleteStudent(int studentId, string fileName)
        {
            return DAL.DAL.DeleteStudent(studentId, fileName);
        }

        public static List<StudentModel> SearchStudent(string searchString)
        {
            return DAL.DAL.SearchStudent(searchString);
        }

        public static bool AssignStudentToCourse(int studentId, int courseId, string fileName)
        {
            return DAL.DAL.AssignStudentToCourse(studentId, courseId, fileName);
        }

        public static List<TeacherModel> DisplayTeacher(string fileName)
        {
            return DAL.DAL.DisplayTeacher(fileName);
        }

        public static bool InsertTeacher(TeacherModel teacher1, string fileName)
        {
            return DAL.DAL.InsertTeacher(teacher1, fileName);
        }

        public static bool UpdateTeacher(TeacherModel teacher, string fileName)
        {
            return DAL.DAL.UpdateTeacher(teacher, fileName);
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

        public static bool ExportDataForSemesterToExcel(int semesterId,string fileName)
        {
            List<ExportDataModel> exportData = DAL.DAL.GetCombinedDataForSemester(semesterId);

            string semesterName = exportData.FirstOrDefault()?.SemesterName;

            return ExportSemesterToExcel(exportData, semesterName,fileName);
        }

        public static bool ExportSemesterToExcel(List<ExportDataModel> exportData, string semesterName,string fileName)
        {
            string filePath = $@"C:\Users\supravatd\Documents\Mindfire\Student_Five_Layers\StudentLayer\ExcelFile\Semester.xlsx";

            try
            {
                FileInfo file = new FileInfo(filePath);
                if (file.Exists)
                {
                    file.Delete();
                }
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (ExcelPackage package = new ExcelPackage(file))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(semesterName);

                    worksheet.Cells[1, 1].Value = "Student ID";
                    worksheet.Cells[1, 2].Value = "Student Name";
                    worksheet.Cells[1, 3].Value = "Course Name";
                    worksheet.Cells[1, 4].Value = "Teacher Name";

                    int row = 2;
                    foreach (var data in exportData)
                    {
                        worksheet.Cells[row, 1].Value = data.StudentId;
                        worksheet.Cells[row, 2].Value = data.StudentName;
                        worksheet.Cells[row, 3].Value = data.CourseName;
                        worksheet.Cells[row, 4].Value = data.TeacherName;
                        row++;
                    }

                    package.Save();
                }

                return true; 
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
                return false; 
            }
        }


    }
}

