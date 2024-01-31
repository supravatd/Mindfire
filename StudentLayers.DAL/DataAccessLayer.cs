using StudentLayers.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace StudentLayers.DAL
{
    public class DataAccessLayer
    {
        public static List<StudentInsert> DisplayStudent(string fileName)
        {
            List<StudentInsert> allStudentsDisplay = new List<StudentInsert>();
            try
            {
                using (EF_Demo_DBEntities stud = new EF_Demo_DBEntities())
                {
                    List<Student> allStudents = stud.Students.Include("Semester").ToList();

                    foreach (var student in allStudents)
                    {
                        string semesterName = student.SemesterId != null ? student.Semester.SemesterName : "";
                        StudentInsert studentDisplay = new StudentInsert
                        {
                            StudentId = student.StudentId,
                            FirstName = student.FirstName,
                            LastName = student.LastName
                        };
                        allStudentsDisplay.Add(studentDisplay);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
            return allStudentsDisplay;
        }

        public static bool InsertStudent(StudentInsert student1, string fileName)
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
                    context.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
                return false;
            }
        }


        public static bool UpdateStudent(int studentId,StudentInsert studentUpdate, string fileName)
        {
            try
            {
                using (EF_Demo_DBEntities stud = new EF_Demo_DBEntities())
                {
                    Student studentToUpdate = stud.Students.Find(studentId);

                    if (studentToUpdate != null)
                    {
                        studentToUpdate.FirstName = studentUpdate.FirstName;
                        studentToUpdate.LastName = studentUpdate.LastName;
                        studentToUpdate.SemesterId = studentUpdate.SemesterId;

                        stud.SaveChanges();

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
                return false;
            }
        }

        public static bool DeleteStudent(int studentId, string fileName)
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

                        return true; 
                    }
                    else
                    {
                        return false; 
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
                return false; 
            }
        }

        public static List<StudentInsert> SearchStudent(string searchString)
        {
            List<StudentInsert> searchResults = new List<StudentInsert>();

            using (EF_Demo_DBEntities context = new EF_Demo_DBEntities())
            {
                var students = from s in context.Students
                               where s.FirstName.Contains(searchString)
                               select new StudentInsert
                               {
                                   StudentId = s.StudentId,
                                   FirstName = s.FirstName,
                                   LastName = s.LastName,
                                   SemesterId = (int)s.SemesterId
                               };

                searchResults.AddRange(students);
            }

            return searchResults;
        }

        public static List<TeacherInsert> DisplayTeacher(string fileName)
        {
            List<TeacherInsert> displayTeachers = new List<TeacherInsert>();
            try
            {
                using (EF_Demo_DBEntities stud = new EF_Demo_DBEntities())
                {
                    List<Teacher> allTeachers = stud.Teachers.ToList();
                    foreach (var teacher in allTeachers)
                    {
                        TeacherInsert displayTeacher = new TeacherInsert
                        {
                            TeacherId = teacher.TeacherId,
                            FirstName = teacher.FirstName,
                            LastName = teacher.LastName,
                            SemesterId = (int)teacher.SemesterId
                        };
                        displayTeachers.Add(displayTeacher);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
            return displayTeachers;
        }

        public static bool InsertTeacher(TeacherInsert teacher, string fileName)
        {
            try
            {
                using (EF_Demo_DBEntities stud = new EF_Demo_DBEntities())
                {
                    Teacher newTeacher = new Teacher
                    {
                        FirstName = teacher.FirstName,
                        LastName = teacher.LastName,
                        SemesterId = teacher.SemesterId
                    };

                    stud.Teachers.Add(newTeacher);
                    stud.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
                return false;
            }
        }

        public static bool UpdateTeacher(int teacherId, TeacherInsert teacher, string fileName)
        {
            try
            {
                using (EF_Demo_DBEntities stud = new EF_Demo_DBEntities())
                {
                    Teacher teacherToUpdate = stud.Teachers.Find(teacherId);

                    if (teacherToUpdate != null)
                    {
                        teacherToUpdate.FirstName = teacher.FirstName;
                        teacherToUpdate.LastName = teacher.LastName;
                        teacherToUpdate.SemesterId = teacher.SemesterId;

                        stud.SaveChanges();
                        return true; 
                    }
                    else
                    {
                        return false; 
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
                return false;
            }
        }

        public static bool DeleteTeacher(int teacherId, string fileName)
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
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
                return false;
            }
        }

        public static List<SemesterInsert> DisplaySemesters(string fileName)
        {
            List<SemesterInsert> allSemesters = null;
            try
            {
                using (EF_Demo_DBEntities dbContext = new EF_Demo_DBEntities())
                {
                    List<Semester> allSem = dbContext.Semesters.ToList();
                    allSemesters = new List<SemesterInsert>();
                    foreach (var semester in allSem)
                    {
                        SemesterInsert output = new SemesterInsert
                        {
                            SemesterId = semester.SemesterId,
                            SemesterName = semester.SemesterName,

                        };
                        allSemesters.Add(output);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
            return allSemesters;
        }

        public static bool InsertSemester(string semesterName, string fileName)
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

                    return true;
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
                return false;
            }
        }

        public static bool UpdateSemester(int semesterId, string newSemesterName, string fileName)
        {
            try
            {
                using (EF_Demo_DBEntities stud = new EF_Demo_DBEntities())
                {
                    Semester semesterToUpdate = stud.Semesters.Find(semesterId);

                    if (semesterToUpdate != null)
                    {
                        semesterToUpdate.SemesterName = newSemesterName;
                        stud.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
                return false;
            }
        }

        public static bool DeleteSemester(int semesterId, string fileName)
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
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
                return false;
            }
        }

        public static List<CourseDisplay> GetCourses(string fileName)
        {
            List<CourseDisplay> allCourses = new List<CourseDisplay>();
            try
            {
                using (EF_Demo_DBEntities stud = new EF_Demo_DBEntities())
                {
                    List<Course> all = stud.Courses.ToList();
                    foreach (var course in all)
                    {
                        CourseDisplay courseDisplay = new CourseDisplay
                        {
                            CourseId = course.CourseId,
                            CourseName = course.CourseName,
                        };
                        allCourses.Add(courseDisplay);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
            return allCourses;
        }

        public static bool InsertCourse(string courseName, string fileName)
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

                    return true;
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
                return false;
            }
        }

        public static bool UpdateCourse(int courseId, string newCourseName, string fileName)
        {
            try
            {
                using (EF_Demo_DBEntities stud = new EF_Demo_DBEntities())
                {
                    Course courseToUpdate = stud.Courses.Find(courseId);

                    if (courseToUpdate != null)
                    {
                        courseToUpdate.CourseName = newCourseName;
                        stud.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
                return false;
            }
        }

        public static bool DeleteCourse(int courseId, string fileName)
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
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
                return false;
            }
        }

        public static List<AddressInsert> DisplayAddress(string fileName)
        {
            List<AddressInsert> allAddresses = new List<AddressInsert>();
            try
            {
                using (EF_Demo_DBEntities stud = new EF_Demo_DBEntities())
                {
                    List<StudentAddress> allStudentAddresses = stud.StudentAddresses.ToList();

                    foreach (var address in allStudentAddresses)
                    {
                        AddressInsert addressInsert = new AddressInsert
                        {
                            StudentId = address.StudentId,
                            Address1 = address.Address1,
                            Address2 = address.Address2,
                            Mobile = address.Mobile,
                            Email = address.Email
                        };

                        allAddresses.Add(addressInsert);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
            return allAddresses;
        }

        public static bool InsertAddress(AddressInsert address, string fileName)
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
                    return true;
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
                return false;
            }
        }


        public static bool UpdateAddress(int studentId,AddressInsert address, string fileName)
        {
            try
            {
                using (EF_Demo_DBEntities stud = new EF_Demo_DBEntities())
                {
                    StudentAddress addressToUpdate = stud.StudentAddresses.Find(studentId);

                    if (addressToUpdate != null)
                    {
                        addressToUpdate.Address1 = address.Address1;
                        addressToUpdate.Address2 = address.Address2;
                        addressToUpdate.Mobile = address.Mobile;
                        addressToUpdate.Email = address.Email;

                        stud.SaveChanges();
                        return true; 
                    }
                    else
                    {
                        return false; 
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
                return false; 
            }
        }

        public static bool DeleteAddress(int studentId, string fileName)
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
                        return true; 
                    }
                    else
                    {
                        return false; 
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
                return false;
            }
        }


    }
}
