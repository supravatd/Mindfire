using StudentLayers.DAL;
using StudentLayers.Utils;
using System;
using System.Collections.Generic;

namespace StudentLayers.Business
{
    public class BusinessLogic
    {
        public static List<StudentInsert> DisplayStudent(string fileName)
        {
            return DAL.DataAccessLayer.DisplayStudent(fileName);
        }

        public static bool InsertStudent(StudentInsert student1, string fileName)
        {
            return DAL.DataAccessLayer.InsertStudent(student1, fileName);
        }

        public static bool UpdateStudent(int studentId,StudentInsert studentInput, string fileName)
        {
            return DAL.DataAccessLayer.UpdateStudent(studentId,studentInput, fileName);
        }

        public static bool DeleteStudent(int studentId, string fileName)
        {
           return DAL.DataAccessLayer.DeleteStudent(studentId, fileName);
        }

        public static List<StudentInsert> SearchStudent(string searchString)
        {
            return DAL.DataAccessLayer.SearchStudent(searchString);
        }

        public static List<TeacherInsert> DisplayTeacher(string fileName)
        {
            return DAL.DataAccessLayer.DisplayTeacher(fileName);
        }

        public static bool InsertTeacher(TeacherInsert teacher1, string fileName)
        {
            return DAL.DataAccessLayer.InsertTeacher(teacher1, fileName);
        }

        public static bool UpdateTeacher(int teacherId, TeacherInsert teacher, string fileName)
        {
            return DAL.DataAccessLayer.UpdateTeacher(teacherId, teacher, fileName);
        }

        public static bool DeleteTeacher(int teacherId, string fileName)
        {
            return DAL.DataAccessLayer.DeleteTeacher(teacherId, fileName);
        }

        public static List<SemesterInsert> DisplaySemesters(string fileName)
        {
            List<SemesterInsert> allSemesters = DAL.DataAccessLayer.DisplaySemesters(fileName);
            return allSemesters;
        }

        public static bool InsertSemester(string semesterName, string fileName)
        {
            bool res = DAL.DataAccessLayer.InsertSemester(semesterName, fileName);
            return res;
        }

        public static bool UpdateSemester(int semesterId, string newSemesterName, string fileName)
        {
            return DAL.DataAccessLayer.UpdateSemester(semesterId, newSemesterName, fileName);
        }

        public static bool DeleteSemester(int semesterId, string fileName)
        {
            return DAL.DataAccessLayer.DeleteSemester(semesterId, fileName);
        }

        public static List<CourseDisplay> DisplayCourse(string fileName)
        {
            return DAL.DataAccessLayer.GetCourses(fileName);
        }

        public static bool InsertCourse(string courseName, string fileName)
        {
            return DAL.DataAccessLayer.InsertCourse(courseName, fileName);
        }

        public static bool UpdateCourse(int courseId, string newCourseName, string fileName)
        {
            return DAL.DataAccessLayer.UpdateCourse(courseId, newCourseName, fileName);
        }

        public static bool DeleteCourse(int courseId, string fileName)
        {
            return DAL.DataAccessLayer.DeleteCourse(courseId, fileName);
        }

        public static List<AddressInsert> DisplayAddress(string fileName)
        {
            return DAL.DataAccessLayer.DisplayAddress(fileName);
        }

        public static bool InsertAddress(AddressInsert address, string fileName)
        {
            return DAL.DataAccessLayer.InsertAddress(address, fileName);
        }

        public static bool UpdateAddress(int studentId, AddressInsert address, string fileName)
        {
            return DAL.DataAccessLayer.UpdateAddress(studentId, address, fileName);
        }

        public static bool DeleteAddress(int studentId, string fileName)
        {
            return DAL.DataAccessLayer.DeleteAddress(studentId, fileName);
        }

    }
}
