using StudentLayer.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentLayer.DAL
{
    public class DAL
    {
        public static List<StudentModel> DisplayStudent(string fileName)
        {
            List<StudentModel> allStudentsDisplay = new List<StudentModel>();
            try
            {
                using (StudentEntities stud = new StudentEntities())
                {
                    List<Student> allStudents = stud.Students.ToList();

                    foreach (var student in allStudents)
                    {
                        StudentModel studentDisplay = new StudentModel
                        {
                            StudentId = student.StudentId,
                            FirstName = student.FirstName,
                            LastName = student.LastName,
                            SemesterId = (int)student.SemesterId
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

        public static bool InsertStudent(StudentModel student1, string fileName)
        {
            try
            {
                using (StudentEntities context = new StudentEntities())
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


        public static bool UpdateStudent(int studentId, StudentModel studentUpdate, string fileName)
        {
            try
            {
                using (StudentEntities stud = new StudentEntities())
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
                using (StudentEntities stud = new StudentEntities())
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

        public static List<StudentModel> SearchStudent(string searchString)
        {
            List<StudentModel> searchResults = new List<StudentModel>();

            using (StudentEntities context = new StudentEntities())
            {
                var students = from s in context.Students
                               where s.FirstName.Contains(searchString)
                               select new StudentModel
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

        public static List<TeacherModel> DisplayTeacher(string fileName)
        {
            List<TeacherModel> displayTeachers = new List<TeacherModel>();
            try
            {
                using (StudentEntities stud = new StudentEntities())
                {
                    List<Teacher> allTeachers = stud.Teachers.ToList();
                    foreach (var teacher in allTeachers)
                    {
                        TeacherModel displayTeacher = new TeacherModel
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

        public static bool InsertTeacher(TeacherModel teacher, string fileName)
        {
            try
            {
                using (StudentEntities stud = new StudentEntities())
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

        public static bool UpdateTeacher(int teacherId, TeacherModel teacher, string fileName)
        {
            try
            {
                using (StudentEntities stud = new StudentEntities())
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
                using (StudentEntities stud = new StudentEntities())
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

        public static List<SemesterModel> DisplaySemesters(string fileName)
        {
            List<SemesterModel> allSemesters = null;
            try
            {
                using (StudentEntities dbContext = new StudentEntities())
                {
                    List<Semester> allSem = dbContext.Semesters.ToList();
                    allSemesters = new List<SemesterModel>();
                    foreach (var semester in allSem)
                    {
                        SemesterModel output = new SemesterModel
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
                using (StudentEntities stud = new StudentEntities())
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
                using (StudentEntities stud = new StudentEntities())
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
                using (StudentEntities stud = new StudentEntities())
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

        public static List<CourseModel> GetCourses(string fileName)
        {
            List<CourseModel> allCourses = new List<CourseModel>();
            try
            {
                using (StudentEntities stud = new StudentEntities())
                {
                    List<Course> all = stud.Courses.ToList();
                    foreach (var course in all)
                    {
                        CourseModel CourseModel = new CourseModel
                        {
                            CourseId = course.CourseId,
                            CourseName = course.CourseName,
                        };
                        allCourses.Add(CourseModel);
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
                using (StudentEntities stud = new StudentEntities())
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
                using (StudentEntities stud = new StudentEntities())
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
                using (StudentEntities stud = new StudentEntities())
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

        public static List<AddressModel> DisplayAddress(string fileName)
        {
            List<AddressModel> allAddresses = new List<AddressModel>();
            try
            {
                using (StudentEntities stud = new StudentEntities())
                {
                    List<Address> allStudentAddresses = stud.Addresses.ToList();

                    foreach (var address in allStudentAddresses)
                    {
                        AddressModel AddressModel = new AddressModel
                        {
                            StudentId = address.StudentId,
                            Street = address.Street,
                            City = address.City,
                            State = address.State,
                            Country = address.Country
                        };

                        allAddresses.Add(AddressModel);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
            return allAddresses;
        }

        public static bool InsertAddress(AddressModel address, string fileName)
        {
            try
            {
                using (StudentEntities stud = new StudentEntities())
                {
                    Address newAddress = new Address
                    {
                        StudentId = address.StudentId,
                        Street = address.Street,
                        City = address.City,
                        State = address.State,
                        Country = address.Country
                    };

                    stud.Addresses.Add(newAddress);
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


        public static bool UpdateAddress(int studentId, AddressModel address, string fileName)
        {
            try
            {
                using (StudentEntities stud = new StudentEntities())
                {
                    Address addressToUpdate = stud.Addresses.Find(studentId);

                    if (addressToUpdate != null)
                    {
                        addressToUpdate.Street = address.Street;
                        addressToUpdate.City = address.City;
                        addressToUpdate.State = address.State;
                        addressToUpdate.Country = address.Country;

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
                using (StudentEntities stud = new StudentEntities())
                {
                    Address addressToDelete = stud.Addresses.Find(studentId);

                    if (addressToDelete != null)
                    {
                        stud.Addresses.Remove(addressToDelete);
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
