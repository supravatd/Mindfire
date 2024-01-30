using StudentLayers.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StudentLayers.DAL
{
    public class DataAccessLayer
    {
        public static void DisplayStudent(string fileName)
        {
            try
            {
                using (EF_Demo_DBEntities stud = new EF_Demo_DBEntities())
                {
                    List<Student> allStudents = stud.Students.Include("Semester").ToList();

                    Console.WriteLine("All Students:");
                    foreach (var student in allStudents)
                    {
                        string semesterName = student.SemesterId != null ? student.Semester.SemesterName : "";
                        Console.WriteLine($"ID: {student.StudentId} Name: {student.FirstName} {student.LastName} Semester: {semesterName}");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
        }

        public static void InsertStudent(StudentInsert student1, string fileName)
        {
            try
            {
                using (EF_Demo_DBEntities context = new EF_Demo_DBEntities())
                {
                    Student student = new Student
                    {
                        FirstName = student1.FirstName,
                        LastName = student1.LastName,
                        SemesterId = student1.SemesterId
                    };

                    context.Students.Add(student);

                    Console.WriteLine("Student added successfully.");
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
        }

        public static void UpdateStudent(int studentId, string fileName)
        {
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
        }

        public static void DeleteStudent(int studentId, string fileName)
        {
            try
            {
                using (EF_Demo_DBEntities stud = new EF_Demo_DBEntities())
                {
                    Student studentToDelete = stud.Students.Find(studentId);

                    if (studentToDelete != null)
                    {
                        stud.Students.Remove(studentToDelete);
                        stud.SaveChanges();

                        Console.WriteLine("Student deleted successfully.");
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
        }

        public static void SearchStudent(string searchString)
        {
            using (EF_Demo_DBEntities context = new EF_Demo_DBEntities())
            {
                var students = from s in context.Students
                               join sem in context.Semesters on s.SemesterId equals sem.SemesterId
                               where s.FirstName.Contains(searchString)
                               select new Student
                               {
                                   StudentId = s.StudentId,
                                   FirstName = s.FirstName,
                                   LastName = s.LastName,
                                   SemesterId = s.SemesterId
                               };

                foreach (var student in students)
                {
                    Console.WriteLine($"Student ID: {student.StudentId}, Name: {student.FirstName} {student.LastName}, Semester: {student.SemesterId}");
                }
            }
        }

        public static void DisplayTeacher(string fileName)
        {
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
        }

        public static void InsertTeacher(TeacherInsert teacher1, string fileName)
        {
            try
            {
                using (EF_Demo_DBEntities stud = new EF_Demo_DBEntities())
                {
                    Teacher newTeacher = new Teacher
                    {
                        FirstName = teacher1.FirstName,
                        LastName = teacher1.LastName,
                        SemesterId = teacher1.SemesterId
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
        }

        public static void UpdateTeacher(int teacherId, string fileName)
        {
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
        }

        public static void DeleteTeacher(int teacherId, string fileName)
        {
            try
            {
                using (EF_Demo_DBEntities stud = new EF_Demo_DBEntities())
                {
                    Teacher teacherToDelete = stud.Teachers.Find(teacherId);

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
        }

        public static void DisplaySemester(string fileName)
        {
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
        }

        public static void InsertSemester(string semesterName, string fileName)
        {
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
        }

        public static void UpdateSemester(int semesterId, string fileName)
        {
            try
            {
                using (EF_Demo_DBEntities stud = new EF_Demo_DBEntities())
                {
                    Semester semesterToUpdate = stud.Semesters.Find(semesterId);

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
        }

        public static void DeleteSemester(int semesterId, string fileName)
        {
            try
            {
                using (EF_Demo_DBEntities stud = new EF_Demo_DBEntities())
                {
                    Semester semesterToDelete = stud.Semesters.Find(semesterId);

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
        }

        public static void DisplayCourse(string fileName)
        {
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
        }

        public static void InsertCourse(string courseName, string fileName)
        {
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
        }

        public static void UpdateCourse(int courseId, string fileName)
        {
            try
            {
                using (EF_Demo_DBEntities stud = new EF_Demo_DBEntities())
                {
                    Course courseToUpdate = stud.Courses.Find(courseId);

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
        }

        public static void DeleteCourse(int courseId, string fileName)
        {
            try
            {
                using (EF_Demo_DBEntities stud = new EF_Demo_DBEntities())
                {
                    Course courseToDelete = stud.Courses.Find(courseId);

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
        }

        public static void DisplayAddress(string fileName)
        {
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
        }

        public static void InsertAddress(AddressInsert address, string fileName)
        {
            try
            {
                using (EF_Demo_DBEntities stud = new EF_Demo_DBEntities())
                {
                    StudentAddress newAddress = new StudentAddress
                    {
                        StudentId = address.StudentId,
                        Address1 = address.Address1,
                        Address2 = address.Address2,
                        Mobile = address.Mobile,
                        Email = address.Email
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
        }

        public static void UpdateAddress(int studentId, string fileName)
        {
            try
            {
                using (EF_Demo_DBEntities stud = new EF_Demo_DBEntities())
                {
                    StudentAddress addressToUpdate = stud.StudentAddresses.Find(studentId);

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
        }

        public static void DeleteAddress(int studentId, string fileName)
        {
            try
            {
                using (EF_Demo_DBEntities stud = new EF_Demo_DBEntities())
                {
                    StudentAddress addressToDelete = stud.StudentAddresses.Find(studentId);

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
        }

    }
}
