using StudentLayers.DAL;
using StudentLayers.Utils;
using System.Collections.Generic;

namespace StudentLayers.Business
{
    public class BusinessLogic
    {
        public static void DisplayStudent(string fileName)
        {
            DAL.DataAccessLayer.DisplayStudent(fileName);
        }

        public static void InsertStudent(StudentInsert student1, string fileName)
        {
            DAL.DataAccessLayer.InsertStudent(student1, fileName);
        }

        public static void UpdateStudent(int studentId, string fileName)
        {
            DAL.DataAccessLayer.UpdateStudent(studentId, fileName);
        }

        public static void DeleteStudent(int studentId, string fileName)
        {
            DAL.DataAccessLayer.DeleteStudent(studentId, fileName);
        }

        public static void SearchStudent(string searchString)
        {
            DAL.DataAccessLayer.SearchStudent(searchString);
        }

        public static void DisplayTeacher(string fileName)
        {
            DAL.DataAccessLayer.DisplayTeacher(fileName);
        }

        public static void InsertTeacher(TeacherInsert teacher1, string fileName)
        {
            DAL.DataAccessLayer.InsertTeacher(teacher1, fileName);
        }

        public static void UpdateTeacher(int teacherId, string fileName)
        {
            DAL.DataAccessLayer.UpdateTeacher(teacherId, fileName);
        }

        public static void DeleteTeacher(int teacherId, string fileName)
        {
            DAL.DataAccessLayer.DeleteTeacher(teacherId, fileName);
        }

        public static void DisplaySemester(string fileName)
        {
            DAL.DataAccessLayer.DisplaySemester(fileName);
        }

        public static void InsertSemester(string semesterName, string fileName)
        {
            DAL.DataAccessLayer.InsertSemester(semesterName, fileName);
        }

        public static void UpdateSemester(int semesterId, string fileName)
        {
            DAL.DataAccessLayer.UpdateSemester(semesterId, fileName);
        }

        public static void DeleteSemester(int semesterId, string fileName)
        {
            DAL.DataAccessLayer.DeleteSemester(semesterId, fileName);
        }

        public static void DisplayCourse(string fileName)
        {
            DAL.DataAccessLayer.DisplayCourse(fileName);
        }

        public static void InsertCourse(string courseName, string fileName)
        {
            DAL.DataAccessLayer.InsertCourse(courseName, fileName);
        }

        public static void UpdateCourse(int courseId, string fileName)
        {
            DAL.DataAccessLayer.UpdateCourse(courseId, fileName);
        }

        public static void DeleteCourse(int courseId, string fileName)
        {
            DAL.DataAccessLayer.DeleteCourse(courseId, fileName);
        }

        public static void DisplayAddress(string fileName)
        {
            DAL.DataAccessLayer.DisplayAddress(fileName);
        }

        public static void InsertAddress(AddressInsert address, string fileName)
        {
            DAL.DataAccessLayer.InsertAddress(address, fileName);
        }

        public static void UpdateAddress(int studentId, string fileName)
        {
            DAL.DataAccessLayer.UpdateAddress(studentId, fileName);
        }

        public static void DeleteAddress(int studentId, string fileName)
        {
            DAL.DataAccessLayer.DeleteAddress(studentId, fileName);
        }

    }
}
