using StudentLayers.Business;
using StudentLayers.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using static StudentLayers.Utils.Utils;

namespace StudentLayers
{
    internal class Program
    {
        static string fileName = "";
        static void Main()
        {
            fileName = DateTime.Now.ToString("yyyyMMdd") + ".txt";
            try
            {
                CrudOperations();
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
            Console.ReadKey();
        }

        public static void CrudOperations()
        {
            int result = 0;
            do
            {
                Console.WriteLine();
                Console.WriteLine($"{(int)CrudOp.View_All_Student} View All Student");
                Console.WriteLine($"{(int)CrudOp.Insert_Student} Insert Student");
                Console.WriteLine($"{(int)CrudOp.Update_Student} Update Student");
                Console.WriteLine($"{(int)CrudOp.Delete_Student} Delete Student");
                Console.WriteLine($"{(int)CrudOp.Search_Student} Search Student");
                Console.WriteLine($"{(int)CrudOp.View_All_Teacher} View All Teacher");
                Console.WriteLine($"{(int)CrudOp.Insert_Teacher} Insert Teacher");
                Console.WriteLine($"{(int)CrudOp.Update_Teacher} Update Teacher");
                Console.WriteLine($"{(int)CrudOp.Delete_Teacher} Delete Teacher");
                Console.WriteLine($"{(int)CrudOp.View_All_Semester} View All Semester");
                Console.WriteLine($"{(int)CrudOp.Insert_Semester} Insert Semester");
                Console.WriteLine($"{(int)CrudOp.Update_Semester} Update Semester");
                Console.WriteLine($"{(int)CrudOp.Delete_Semester} Delete Semester");
                Console.WriteLine($"{(int)CrudOp.View_All_Course} View All Course");
                Console.WriteLine($"{(int)CrudOp.Insert_Course} Insert Course");
                Console.WriteLine($"{(int)CrudOp.Update_Course} Update Course");
                Console.WriteLine($"{(int)CrudOp.Delete_Course} Delete Course");
                Console.WriteLine($"{(int)CrudOp.View_All_Address} View All Address");
                Console.WriteLine($"{(int)CrudOp.Insert_Address} Insert Address");
                Console.WriteLine($"{(int)CrudOp.Update_Address} Update Address");
                Console.WriteLine($"{(int)CrudOp.Delete_Address} Delete Address");
                Console.WriteLine($"{(int)CrudOp.Exit} Exit");

                Console.Write("Enter your Choice:");
                result = int.Parse(Console.ReadLine());
                CrudOp input = (CrudOp)result;

                switch (input)
                {
                    case CrudOp.View_All_Student:
                        List<StudentInsert> allStudents = Business.BusinessLogic.DisplayStudent(fileName);
                        if (allStudents != null && allStudents.Count > 0)
                        {
                            Console.WriteLine("All Students:");
                            foreach (var student in allStudents)
                            {
                                Console.WriteLine($"ID: {student.StudentId} Name: {student.FirstName} {student.LastName}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No students found.");
                        }
                        break;

                    case CrudOp.Insert_Student:
                        CaseInsertStudent();
                        break;

                    case CrudOp.Update_Student:
                        CaseUpdateStudent();
                        break;

                    case CrudOp.Delete_Student:
                        CaseDeleteStudent();
                        break;

                    case CrudOp.Search_Student:
                        CaseSearchStudent();
                        break;

                    case CrudOp.View_All_Teacher:
                        List<TeacherInsert> allTeachers = Business.BusinessLogic.DisplayTeacher(fileName);
                        if (allTeachers != null && allTeachers.Count > 0)
                        {
                            Console.WriteLine("All Teachers:");
                            foreach (var teacher in allTeachers)
                            {
                                Console.WriteLine($"Teacher ID: {teacher.TeacherId}, First Name: {teacher.FirstName}, Last Name: {teacher.LastName}, Semester ID: {teacher.SemesterId}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No teachers found.");
                        }
                        break;

                    case CrudOp.Insert_Teacher:
                        CaseInsertTeacher();
                        break;

                    case CrudOp.Update_Teacher:
                        CaseUpdateTeacher();
                        break;

                    case CrudOp.Delete_Teacher:
                        CaseDeleteTeacher();
                        break;

                    case CrudOp.View_All_Semester:
                        List<SemesterInsert> allSemesters = BusinessLogic.DisplaySemesters(fileName);
                        foreach (var semester in allSemesters)
                        {
                            Console.WriteLine($"ID: {semester.SemesterId}, Name: {semester.SemesterName}");
                        }
                        break;

                    case CrudOp.Insert_Semester:
                        CaseInsertSemester();
                        break;

                    case CrudOp.Update_Semester:
                        CaseUpdateSemester();
                        break;

                    case CrudOp.Delete_Semester:
                        CaseDeleteSemester();
                        break;

                    case CrudOp.View_All_Course:
                        List<CourseDisplay> allCourses = Business.BusinessLogic.DisplayCourse(fileName);
                        foreach (var course in allCourses)
                        {
                            Console.WriteLine($"ID: {course.CourseId}, Name: {course.CourseName}");
                        }
                        break;

                    case CrudOp.Insert_Course:
                        CaseInsertCourse();
                        break;

                    case CrudOp.Update_Course:
                        CaseUpdateCourse();
                        break;

                    case CrudOp.Delete_Course:
                        CaseDeleteCourse();
                        break;

                    case CrudOp.View_All_Address:
                        List<AddressInsert> allAddresses = Business.BusinessLogic.DisplayAddress(fileName);
                        foreach (var address in allAddresses)
                        {
                            Console.WriteLine($"Student ID: {address.StudentId}, Address1: {address.Address1}, Address2: {address.Address2}, Mobile: {address.Mobile}, Email: {address.Email}");
                        }
                        break;

                    case CrudOp.Insert_Address:
                        CaseInsertAddress();
                        break;

                    case CrudOp.Update_Address:
                        CaseUpdateAddress();
                        break;

                    case CrudOp.Delete_Address:
                        CaseDeleteAddress();
                        break;

                    case CrudOp.Exit:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Press any Key to Exit...");
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Enter a Valid No...");
                        break;

                }
            } while (result != 21);
        }

        private static void CaseSearchStudent()
        {
            try
            {
                Console.WriteLine("Enter the search string:");
                string searchString = Console.ReadLine();

                List<StudentInsert> searchResults = Business.BusinessLogic.SearchStudent(searchString);

                if (searchResults.Count > 0)
                {
                    Console.WriteLine("Search Results:");
                    foreach (var result in searchResults)
                    {
                        Console.WriteLine($"Student ID: {result.StudentId}, Name: {result.FirstName} {result.LastName}, Semester: {result.SemesterId}");
                    }
                }
                else
                {
                    Console.WriteLine("No students found matching the search criteria.");
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
        }

        private static void CaseInsertStudent()
        {
            try
            {
                string firstName = GetValidStringInput("First Name");
                string lastName = GetValidStringInput("Last Name");
                int semesterId = GetValidIntegerInput("Semester ID");

                StudentInsert student = new StudentInsert { FirstName = firstName, LastName = lastName, SemesterId = semesterId };
                Business.BusinessLogic.InsertStudent(student, fileName);
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
        }

        private static void CaseUpdateStudent()
        {
            try
            {
                int studentId = GetValidIntegerInput("Student ID");
                string newFirstName = GetValidStringInput("New First Name");
                string newLastName = GetValidStringInput("New Last Name");
                int newSemesterId = GetValidIntegerInput("New Semester ID");

                StudentInsert studentInput = new StudentInsert
                {
                    FirstName = newFirstName,
                    LastName = newLastName,
                    SemesterId = newSemesterId
                };
                bool isUpdated = Business.BusinessLogic.UpdateStudent(studentId, studentInput, fileName);
                if (isUpdated)
                {
                    Console.WriteLine("Student updated successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to update student. Student not found.");
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
        }

        private static void CaseDeleteStudent()
        {
            try
            {
                int studentId = GetValidIntegerInput("Student ID");
                bool isDeleted = Business.BusinessLogic.DeleteStudent(studentId, fileName);

                if (isDeleted)
                {
                    Console.WriteLine("Student deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to delete student. Student not found.");
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
        }

        private static void CaseInsertTeacher()
        {
            try
            {
                string firstName = GetValidStringInput("First Name");
                string lastName = GetValidStringInput("Last Name");
                int semesterId = GetValidIntegerInput("Semester ID");

                TeacherInsert teacher1 = new TeacherInsert { FirstName = firstName, LastName = lastName, SemesterId = semesterId };
                bool isInserted = Business.BusinessLogic.InsertTeacher(teacher1, fileName);

                if (isInserted)
                {
                    Console.WriteLine("Teacher added successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to add teacher.");
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
        }

        private static void CaseUpdateTeacher()
        {
            try
            {
                int teacherId = GetValidIntegerInput("Teacher ID");
                string newFirstName = GetValidStringInput("New First Name");
                string newLastName = GetValidStringInput("New Last Name");
                int newSemesterId = GetValidIntegerInput("New Semester ID");

                TeacherInsert teacherInput = new TeacherInsert
                {
                    FirstName = newFirstName,
                    LastName = newLastName,
                    SemesterId = newSemesterId
                };

                bool isUpdated = Business.BusinessLogic.UpdateTeacher(teacherId, teacherInput, fileName);

                if (isUpdated)
                {
                    Console.WriteLine("Teacher updated successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to update teacher. Teacher not found.");
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
        }

        private static void CaseDeleteTeacher()
        {
            try
            {
                int teacherId = GetValidIntegerInput("Teacher ID");
                bool isDeleted = Business.BusinessLogic.DeleteTeacher(teacherId, fileName);

                if (isDeleted)
                {
                    Console.WriteLine("Teacher deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to delete teacher. Teacher not found.");
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
        }

        private static void CaseInsertSemester()
        {
            try
            {
                string semesterName = GetValidStringInput("Semester Name");
                bool isInserted = Business.BusinessLogic.InsertSemester(semesterName, fileName);
                if (isInserted)
                {
                    Console.WriteLine("Semester Inserted Successfully");
                }
                else
                {
                    Console.WriteLine("Semester Not Inserted");
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
        }

        private static void CaseUpdateSemester()
        {
            try
            {
                int semesterId = GetValidIntegerInput("Semester ID");
                string newSemesterName = GetValidStringInput("New Semester Name");

                bool isUpdated = Business.BusinessLogic.UpdateSemester(semesterId, newSemesterName, fileName);

                if (isUpdated)
                {
                    Console.WriteLine("Semester updated successfully.");
                }
                else
                {
                    Console.WriteLine("Semester not found or update failed.");
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
        }

        private static void CaseDeleteSemester()
        {
            try
            {
                int semesterId = GetValidIntegerInput("Semester ID");
                bool isDeleted = Business.BusinessLogic.DeleteSemester(semesterId, fileName);

                if (isDeleted)
                {
                    Console.WriteLine("Semester deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Semester not found or delete failed.");
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
        }

        private static void CaseInsertCourse()
        {
            try
            {
                string courseName = GetValidStringInput("Course Name");
                bool isInserted = Business.BusinessLogic.InsertCourse(courseName, fileName);

                if (isInserted)
                {
                    Console.WriteLine("Course added successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to add course.");
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
        }

        private static void CaseUpdateCourse()
        {
            try
            {
                int courseId = GetValidIntegerInput("Course ID");
                string newCourseName = GetValidStringInput("New Course Name");

                bool isUpdated = Business.BusinessLogic.UpdateCourse(courseId, newCourseName, fileName);

                if (isUpdated)
                {
                    Console.WriteLine("Course updated successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to update course.");
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
        }

        private static void CaseDeleteCourse()
        {
            try
            {
                int courseId = GetValidIntegerInput("Course ID");
                bool isDeleted = Business.BusinessLogic.DeleteCourse(courseId, fileName);

                if (isDeleted)
                {
                    Console.WriteLine("Course deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to delete course.");
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
        }

        private static void CaseInsertAddress()
        {
            try
            {
                int studentId = GetValidIntegerInput("Student ID");
                string address1 = GetValidStringInput("Address1");
                string address2 = GetValidStringInput("Address2");
                string mobile = GetValidStringInput("Mobile");
                string email = GetValidStringInput("Email");

                AddressInsert address = new AddressInsert { StudentId = studentId, Address1 = address1, Address2 = address2, Mobile = mobile, Email = email };

                bool isInserted = Business.BusinessLogic.InsertAddress(address, fileName);

                if (isInserted)
                {
                    Console.WriteLine("Student address added successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to add student address.");
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
        }

        private static void CaseUpdateAddress()
        {
            try
            {
                int studentId = GetValidIntegerInput("Student ID");
                string address1 = GetValidStringInput("Address1");
                string address2 = GetValidStringInput("Address2");
                string mobile = GetValidStringInput("Mobile");
                string email = GetValidStringInput("Email");

                AddressInsert address = new AddressInsert { Address1 = address1, Address2 = address2, Mobile = mobile, Email = email };
                bool isUpdated = Business.BusinessLogic.UpdateAddress(studentId, address, fileName);
                if (isUpdated)
                {
                    Console.WriteLine("Student address updated successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to update student address OR Student address not found.");
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
        }

        private static void CaseDeleteAddress()
        {
            try
            {
                int studentId = GetValidIntegerInput("Student ID");
                bool isDeleted = Business.BusinessLogic.DeleteAddress(studentId, fileName);

                if (isDeleted)
                {
                    Console.WriteLine("Student address deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to delete student address. Student address not found.");
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
        }

        private static int GetValidIntegerInput(string fieldName)
        {
            int value;
            do
            {
                Console.WriteLine($"Enter {fieldName}:");
                if (!int.TryParse(Console.ReadLine(), out value))
                {
                    Console.WriteLine($"Invalid input for {fieldName}.");
                }
            } while (!int.TryParse(value.ToString(), out _));
            return value;
        }

        private static string GetValidStringInput(string fieldName)
        {
            string input;
            do
            {
                Console.WriteLine($"Enter {fieldName}:");
                input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input) || !input.All(char.IsLetter))
                {
                    Console.WriteLine($"Invalid input for {fieldName}.");
                }
            } while (string.IsNullOrWhiteSpace(input) || !input.All(char.IsLetter));
            return input;
        }
    }
}
