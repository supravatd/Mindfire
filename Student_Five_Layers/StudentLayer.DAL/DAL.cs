using AutoMapper;
using StudentLayer.Models.ModelView;
using StudentLayer.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;

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
                    var mapper = MapperConfig.ConfigureDisplayMapper();
                    allStudentsDisplay = mapper.Map<List<Student>, List<StudentModel>>(allStudents);
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
                    var mapper = MapperConfig.ConfigureInsertMapper();
                    Student student = mapper.Map<StudentModel, Student>(student1);

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


        public static bool UpdateStudent(StudentModel studentUpdate, string fileName)
        {
            try
            {
                using (StudentEntities stud = new StudentEntities())
                {
                    Student studentToUpdate = stud.Students.Find(studentUpdate.StudentId);
                    var mapper = MapperConfig.ConfigureUpdateMapper();
                    if (studentToUpdate != null)
                    {
                        mapper.Map(studentUpdate, studentToUpdate);
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
                    var mapper = MapperConfig.ConfigureDisplayMapper();
                    displayTeachers = mapper.Map<List<Teacher>, List<TeacherModel>>(allTeachers);
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
            return displayTeachers;
        }

        public static bool InsertTeacher(TeacherModel teacher1, string fileName)
        {
            try
            {
                using (StudentEntities stud = new StudentEntities())
                {
                    var mapper = MapperConfig.ConfigureInsertMapper();
                    Teacher teacher = mapper.Map<TeacherModel, Teacher>(teacher1);
                    stud.Teachers.Add(teacher);
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

        public static bool UpdateTeacher(TeacherModel teacher, string fileName)
        {
            try
            {
                using (StudentEntities stud = new StudentEntities())
                {
                    Teacher teacherToUpdate = stud.Teachers.Find(teacher.TeacherId);
                    var mapper = MapperConfig.ConfigureUpdateMapper();
                    if (teacherToUpdate != null)
                    {
                        mapper.Map(teacher, teacherToUpdate);

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
                    var mapper = MapperConfig.ConfigureDisplayMapper();
                    allAddresses = mapper.Map<List<Address>, List<AddressModel>>(allStudentAddresses);
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
                    var mapper = MapperConfig.ConfigureInsertMapper();
                    Address newAddress = mapper.Map<AddressModel, Address>(address);
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
                    var mapper = MapperConfig.ConfigureUpdateMapper();


                    if (addressToUpdate != null)
                    {
                        mapper.Map(address, addressToUpdate);
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

        public static bool AssignStudentToCourse(int studentId, int courseId, string fileName)
        {
            try
            {
                using (StudentEntities stud = new StudentEntities())
                {
                    if (stud.StudentCourses.Any(sc => sc.StudentId == studentId && sc.CourseId == courseId))
                    {
                        return false;
                    }
                    var studentCourse = new StudentCourse { StudentId = studentId, CourseId = courseId };
                    stud.StudentCourses.Add(studentCourse);
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

        public static List<ExportDataModel> GetCombinedDataForSemester(int semesterId)
        {
            using (var context = new StudentEntities())
            {
                var semesterName = context.Semesters
                                         .Where(s => s.SemesterId == semesterId)
                                         .Select(s => s.SemesterName)
                                         .FirstOrDefault();

                var combinedData = from teacher in context.Teachers
                                   join course in context.Courses on teacher.TeacherId equals course.TeacherId
                                   join studentCourse in context.StudentCourses on course.CourseId equals studentCourse.CourseId
                                   join student in context.Students on studentCourse.StudentId equals student.StudentId
                                   where course.SemesterId == semesterId
                                   select new ExportDataModel
                                   {
                                       StudentId = student.StudentId,
                                       StudentName = student.FirstName + " " + student.LastName,
                                       CourseName = course.CourseName,
                                       TeacherName = teacher.FirstName + " " + teacher.LastName,
                                       SemesterName = semesterName
                                   };

                return combinedData.ToList();
            }
        }

    }
}
