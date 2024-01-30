using StudentLayers.Business;
using StudentLayers.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
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
                        Business.BusinessLogic.DisplayStudent(fileName);
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
                        Business.BusinessLogic.DisplayTeacher(fileName);
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
                        Business.BusinessLogic.DisplaySemester(fileName);
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
                        Business.BusinessLogic.DisplayCourse(fileName);
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
                        Business.BusinessLogic.DisplayAddress(fileName);
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

                Business.BusinessLogic.SearchStudent(searchString);
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
                Business.BusinessLogic.UpdateStudent(studentId, fileName);
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
                Business.BusinessLogic.DeleteStudent(studentId, fileName);
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
                Business.BusinessLogic.InsertTeacher(teacher1, fileName);
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
                Business.BusinessLogic.UpdateTeacher(teacherId, fileName);
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
                Business.BusinessLogic.DeleteTeacher(teacherId, fileName);
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
                Business.BusinessLogic.InsertSemester(semesterName, fileName);
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
                Business.BusinessLogic.UpdateSemester(semesterId, fileName);
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
                Business.BusinessLogic.DeleteSemester(semesterId, fileName);
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
                Business.BusinessLogic.InsertCourse(courseName, fileName);
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
                Business.BusinessLogic.UpdateCourse(courseId, fileName);
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
                Business.BusinessLogic.DeleteCourse(courseId, fileName);
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
        }

        public static void CaseInsertAddress()
        {
            try
            {
                int studentId = GetValidIntegerInput("Student ID");
                string address1 = GetValidStringInput("Address1");
                string address2 = GetValidStringInput("Address2");
                string mobile = GetValidStringInput("Mobile");
                string email = GetValidStringInput("Email");

                AddressInsert address = new AddressInsert { StudentId = studentId, Address1 = address1, Address2 = address2, Mobile = mobile, Email = email };
                Business.BusinessLogic.InsertAddress(address, fileName);
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
                Business.BusinessLogic.UpdateAddress(studentId, fileName);
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
                Business.BusinessLogic.DeleteAddress(studentId, fileName);
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
