using System;
using System.Collections.Generic;
using System.Linq;

namespace CrudEntityFramework
{
    internal class Program
    {
        static String fileName = "";
        enum CrudOp
        {
            View_All_Student = 1,
            Insert_Student,
            Update_Student,
            Delete_Student,
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
            Exit
        }
        static void Main(string[] args)
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

        private static void CrudOperations()
        {
            int result = 0;
            do
            {
                Console.WriteLine();
                Console.WriteLine($"{(int)CrudOp.View_All_Student} View All Student");
                Console.WriteLine($"{(int)CrudOp.Insert_Student} Insert Student");
                Console.WriteLine($"{(int)CrudOp.Update_Student} Update Student");
                Console.WriteLine($"{(int)CrudOp.Delete_Student} Delete Student");
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

                result = int.Parse(Console.ReadLine());
                CrudOp input = (CrudOp)result;

                switch (input)
                {
                    case CrudOp.View_All_Student:
                        try
                        {
                            using (EF_Demo_DBEntities stud = new EF_Demo_DBEntities())
                            {
                                List<Student> allStudents = stud.Students.ToList();

                                Console.WriteLine("All Students:");
                                foreach (var student in allStudents)
                                {
                                    Console.WriteLine($"ID: {student.StudentId}, Name: {student.FirstName} {student.LastName}");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.AddData(ex, fileName);
                        }
                        break;

                    case CrudOp.Insert_Student:

                        Console.WriteLine("Enter First Name:");
                        string studFirstName = Console.ReadLine();

                        Console.WriteLine("Enter Last Name:");
                        string studLastName = Console.ReadLine();

                        Console.WriteLine("Enter Semester ID:");
                        int semesterId = int.Parse(Console.ReadLine());

                        try
                        {
                            using (EF_Demo_DBEntities stud = new EF_Demo_DBEntities())
                            {
                                Student newStudent = new Student
                                {
                                    FirstName = studFirstName,
                                    LastName = studLastName,
                                    SemesterId = semesterId
                                };

                                stud.Students.Add(newStudent);
                                stud.SaveChanges();

                                Console.WriteLine("Student added successfully.");
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.AddData(ex, fileName);
                        }
                        break;

                    case CrudOp.Update_Student:

                        Console.WriteLine("Enter Student ID:");
                        int studentId = int.Parse(Console.ReadLine());

                        try
                        {
                            using (EF_Demo_DBEntities stud = new EF_Demo_DBEntities())
                            {
                                Student studentToUpdate = stud.Students.Find(studentId);

                                if (studentToUpdate != null)
                                {
                                    Console.WriteLine("Enter new First Name:");
                                    string newFirstName = Console.ReadLine();

                                    Console.WriteLine("Enter new Last Name:");
                                    string newLastName = Console.ReadLine();

                                    Console.WriteLine("Enter new Semester ID:");
                                    int newSemesterId = int.Parse(Console.ReadLine());

                                    studentToUpdate.FirstName = newFirstName;
                                    studentToUpdate.LastName = newLastName;
                                    studentToUpdate.SemesterId = newSemesterId;

                                    stud.SaveChanges();

                                    Console.WriteLine("Student updated successfully.");
                                }
                                else
                                {
                                    Console.WriteLine("Student not found.");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.AddData(ex, fileName);
                        }
                        break;

                    case CrudOp.Delete_Student:
                        Console.WriteLine("Enter Student ID:");
                        int delStudentId = int.Parse(Console.ReadLine());

                        try
                        {
                            using (EF_Demo_DBEntities stud = new EF_Demo_DBEntities())
                            {
                                var studentCourses = stud.vwStudentCourses.Where(sc => sc.StudentId == delStudentId).ToList();

                                if (studentCourses.Any())
                                {
                                    foreach (var studentCourse in studentCourses)
                                    {
                                        Course courseToDelete = stud.Courses.Find(studentCourse.CourseId);
                                        if (courseToDelete != null)
                                        {
                                            stud.Courses.Remove(courseToDelete);
                                        }
                                    }

                                    Student studentToDelete = stud.Students.Find(delStudentId);
                                    if (studentToDelete != null)
                                    {
                                        stud.Students.Remove(studentToDelete);
                                    }

                                    stud.SaveChanges();
                                    Console.WriteLine("Student and associated courses deleted successfully.");
                                }
                                else
                                {
                                    Console.WriteLine("No associated courses found for the student.");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.AddData(ex, fileName);
                        }


                        break;

                    case CrudOp.View_All_Teacher:
                        try
                        {
                            using (EF_Demo_DBEntities stud = new EF_Demo_DBEntities())
                            {
                                List<Teacher> allTeachers = stud.Teachers.ToList();

                                Console.WriteLine("All Teachers:");
                                foreach (var teacher in allTeachers)
                                {
                                    Console.WriteLine($"Teacher ID: {teacher.TeacherId}, First Name: {teacher.FirstName}, Last Name: {teacher.LastName}, Semester ID: {teacher.SemesterId}");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.AddData(ex, fileName);
                        }
                        break;

                    case CrudOp.Insert_Teacher:
                        Console.WriteLine("Enter First Name:");
                        string teachFirstName = Console.ReadLine();

                        Console.WriteLine("Enter Last Name:");
                        string teachLastName = Console.ReadLine();

                        Console.WriteLine("Enter Semester ID:");
                        int teachSemesterId = int.Parse(Console.ReadLine());

                        try
                        {
                            using (EF_Demo_DBEntities stud = new EF_Demo_DBEntities())
                            {
                                Teacher newTeacher = new Teacher
                                {
                                    FirstName = teachFirstName,
                                    LastName = teachLastName,
                                    SemesterId = teachSemesterId
                                };

                                stud.Teachers.Add(newTeacher);
                                stud.SaveChanges();

                                Console.WriteLine("Teacher added successfully.");
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.AddData(ex, fileName);
                        }
                        break;

                    case CrudOp.Update_Teacher:
                        Console.WriteLine("Enter Teacher ID:");
                        int teacherId = int.Parse(Console.ReadLine());

                        try
                        {
                            using (EF_Demo_DBEntities stud = new EF_Demo_DBEntities())
                            {
                                Teacher teacherToUpdate = stud.Teachers.Find(teacherId);

                                if (teacherToUpdate != null)
                                {
                                    Console.WriteLine("Enter new First Name:");
                                    string newFirstName = Console.ReadLine();

                                    Console.WriteLine("Enter new Last Name:");
                                    string newLastName = Console.ReadLine();

                                    Console.WriteLine("Enter new Semester ID:");
                                    int newSemesterId = int.Parse(Console.ReadLine());

                                    teacherToUpdate.FirstName = newFirstName;
                                    teacherToUpdate.LastName = newLastName;
                                    teacherToUpdate.SemesterId = newSemesterId;

                                    stud.SaveChanges();

                                    Console.WriteLine("Teacher updated successfully.");
                                }
                                else
                                {
                                    Console.WriteLine("Teacher not found.");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.AddData(ex, fileName);
                        }
                        break;

                    case CrudOp.Delete_Teacher:
                        Console.WriteLine("Enter Teacher ID:");
                        int delTeacherId = int.Parse(Console.ReadLine());

                        try
                        {
                            using (EF_Demo_DBEntities stud = new EF_Demo_DBEntities())
                            {
                                Teacher teacherToDelete = stud.Teachers.Find(delTeacherId);

                                if (teacherToDelete != null)
                                {
                                    stud.Teachers.Remove(teacherToDelete);
                                    stud.SaveChanges();

                                    Console.WriteLine("Teacher deleted successfully.");
                                }
                                else
                                {
                                    Console.WriteLine("Teacher not found.");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.AddData(ex, fileName);
                        }
                        break;

                    case CrudOp.View_All_Semester:
                        try
                        {
                            using (EF_Demo_DBEntities stud = new EF_Demo_DBEntities())
                            {
                                List<Semester> allSemesters = stud.Semesters.ToList();

                                Console.WriteLine("All Semesters:");
                                foreach (var semester in allSemesters)
                                {
                                    Console.WriteLine($"ID: {semester.SemesterId}, Name: {semester.SemesterName}");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.AddData(ex, fileName);
                        }
                        break;

                    case CrudOp.Insert_Semester:
                        Console.WriteLine("Enter Semester Name:");
                        string semesterName = Console.ReadLine();

                        try
                        {
                            using (EF_Demo_DBEntities stud = new EF_Demo_DBEntities())
                            {
                                Semester newSemester = new Semester
                                {
                                    SemesterName = semesterName
                                };

                                stud.Semesters.Add(newSemester);
                                stud.SaveChanges();

                                Console.WriteLine("Semester added successfully.");
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.AddData(ex, fileName);
                        }
                        break;

                    case CrudOp.Update_Semester:
                        Console.WriteLine("Enter Semester ID:");
                        int upSemesterId = int.Parse(Console.ReadLine());

                        try
                        {
                            using (EF_Demo_DBEntities stud = new EF_Demo_DBEntities())
                            {
                                Semester semesterToUpdate = stud.Semesters.Find(upSemesterId);

                                if (semesterToUpdate != null)
                                {
                                    Console.WriteLine("Enter new name:");
                                    string newSemesterName = Console.ReadLine();

                                    semesterToUpdate.SemesterName = newSemesterName;
                                    stud.SaveChanges();

                                    Console.WriteLine("Semester updated successfully.");
                                }
                                else
                                {
                                    Console.WriteLine("Semester not found.");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.AddData(ex, fileName);
                        }
                        break;

                    case CrudOp.Delete_Semester:
                        Console.WriteLine("Enter Semester ID:");
                        int delSemesterId = int.Parse(Console.ReadLine());

                        try
                        {
                            using (EF_Demo_DBEntities stud = new EF_Demo_DBEntities())
                            {
                                Semester semesterToDelete = stud.Semesters.Find(delSemesterId);

                                if (semesterToDelete != null)
                                {
                                    stud.Semesters.Remove(semesterToDelete);
                                    stud.SaveChanges();

                                    Console.WriteLine("Semester deleted successfully.");
                                }
                                else
                                {
                                    Console.WriteLine("Semester not found.");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.AddData(ex, fileName);
                        }
                        break;

                    case CrudOp.View_All_Course:
                        try
                        {
                            using (EF_Demo_DBEntities stud = new EF_Demo_DBEntities())
                            {
                                List<Course> allCourses = stud.Courses.ToList();

                                Console.WriteLine("All Courses:");
                                foreach (var course in allCourses)
                                {
                                    Console.WriteLine($"ID: {course.CourseId}, Name: {course.CourseName}");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.AddData(ex, fileName);
                        }
                        break;

                    case CrudOp.Insert_Course:
                        Console.WriteLine("Enter Course Name:");
                        string courseName = Console.ReadLine();

                        try
                        {
                            using (EF_Demo_DBEntities stud = new EF_Demo_DBEntities())
                            {
                                Course newCourse = new Course
                                {
                                    CourseName = courseName
                                };

                                stud.Courses.Add(newCourse);
                                stud.SaveChanges();

                                Console.WriteLine("Course added successfully.");
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.AddData(ex, fileName);
                        }
                        break;

                    case CrudOp.Update_Course:
                        Console.WriteLine("Enter Course ID:");
                        int upCourseId = int.Parse(Console.ReadLine());

                        try
                        {
                            using (EF_Demo_DBEntities stud = new EF_Demo_DBEntities())
                            {
                                Course courseToUpdate = stud.Courses.Find(upCourseId);

                                if (courseToUpdate != null)
                                {
                                    Console.WriteLine("Enter new name:");
                                    string newCourseName = Console.ReadLine();

                                    courseToUpdate.CourseName = newCourseName;
                                    stud.SaveChanges();

                                    Console.WriteLine("Course updated successfully.");
                                }
                                else
                                {
                                    Console.WriteLine("Course not found.");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.AddData(ex, fileName);
                        }
                        break;

                    case CrudOp.Delete_Course:
                        Console.WriteLine("Enter Course ID:");
                        int delCourseId = int.Parse(Console.ReadLine());

                        try
                        {
                            using (EF_Demo_DBEntities stud = new EF_Demo_DBEntities())
                            {
                                Course courseToDelete = stud.Courses.Find(delCourseId);

                                if (courseToDelete != null)
                                {
                                    stud.Courses.Remove(courseToDelete);
                                    stud.SaveChanges();

                                    Console.WriteLine("Course deleted successfully.");
                                }
                                else
                                {
                                    Console.WriteLine("Course not found.");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.AddData(ex, fileName);
                        }
                        break;

                    case CrudOp.View_All_Address:
                        try
                        {
                            using (EF_Demo_DBEntities stud = new EF_Demo_DBEntities())
                            {
                                List<StudentAddress> allAddresses = stud.StudentAddresses.ToList();

                                Console.WriteLine("All Student Addresses:");
                                foreach (var address in allAddresses)
                                {
                                    Console.WriteLine($"Student ID: {address.StudentId}, Address1: {address.Address1}, Address2: {address.Address2}, Mobile: {address.Mobile}, Email: {address.Email}");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.AddData(ex, fileName);
                        }
                        break;

                    case CrudOp.Insert_Address:
                        Console.WriteLine("Enter Student ID:");
                        int addStudentId = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter Address1:");
                        string address1 = Console.ReadLine();

                        Console.WriteLine("Enter Address2:");
                        string address2 = Console.ReadLine();

                        Console.WriteLine("Enter Mobile:");
                        string mobile = Console.ReadLine();

                        Console.WriteLine("Enter Email:");
                        string email = Console.ReadLine();

                        try
                        {
                            using (EF_Demo_DBEntities stud = new EF_Demo_DBEntities())
                            {
                                StudentAddress newAddress = new StudentAddress
                                {
                                    StudentId = addStudentId,
                                    Address1 = address1,
                                    Address2 = address2,
                                    Mobile = mobile,
                                    Email = email
                                };

                                stud.StudentAddresses.Add(newAddress);
                                stud.SaveChanges();

                                Console.WriteLine("Student address added successfully.");
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.AddData(ex, fileName);
                        }
                        break;

                    case CrudOp.Update_Address:
                        Console.WriteLine("Enter Student ID:");
                        int upAddStudentId = int.Parse(Console.ReadLine());

                        try
                        {
                            using (EF_Demo_DBEntities stud = new EF_Demo_DBEntities())
                            {
                                StudentAddress addressToUpdate = stud.StudentAddresses.Find(upAddStudentId);

                                if (addressToUpdate != null)
                                {
                                    Console.WriteLine("Enter new Address1:");
                                    string newAddress1 = Console.ReadLine();

                                    Console.WriteLine("Enter new Address2:");
                                    string newAddress2 = Console.ReadLine();

                                    Console.WriteLine("Enter new Mobile:");
                                    string newMobile = Console.ReadLine();

                                    Console.WriteLine("Enter new Email:");
                                    string newEmail = Console.ReadLine();

                                    addressToUpdate.Address1 = newAddress1;
                                    addressToUpdate.Address2 = newAddress2;
                                    addressToUpdate.Mobile = newMobile;
                                    addressToUpdate.Email = newEmail;

                                    stud.SaveChanges();

                                    Console.WriteLine("Student address updated successfully.");
                                }
                                else
                                {
                                    Console.WriteLine("Student address not found.");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.AddData(ex, fileName);
                        }
                        break;

                    case CrudOp.Delete_Address:
                        Console.WriteLine("Enter Student ID:");
                        int delAddStudentId = int.Parse(Console.ReadLine());

                        try
                        {
                            using (EF_Demo_DBEntities stud = new EF_Demo_DBEntities())
                            {
                                StudentAddress addressToDelete = stud.StudentAddresses.Find(delAddStudentId);

                                if (addressToDelete != null)
                                {
                                    stud.StudentAddresses.Remove(addressToDelete);
                                    stud.SaveChanges();

                                    Console.WriteLine("Student address deleted successfully.");
                                }
                                else
                                {
                                    Console.WriteLine("Student address not found.");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.AddData(ex, fileName);
                        }
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
            }
            while (result != 21);
        }
    }
}
