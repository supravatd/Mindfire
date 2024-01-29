using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    internal class Practise
    {
        static void Main(string[] args)
        {

            //Include Function OR JOIN
            /*var StudentList1 = context.Students.Include("StudentAddress").ToList();
            foreach (var student in StudentList1)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} {student.StudentAddress?.Address1} {student.StudentAddress?.Address2} {student.StudentAddress?.Mobile}");
            }*/

            //Modify without Tracking
            /*var studentList = context.Students.AsNoTracking().ToList();
            foreach (var student in studentList)
            {
                Console.WriteLine($"Entities with AsNoTracking Entity State: {context.Entry(student).State}");
            }
            foreach (var student in studentList)
            {
                student.FirstName = student.FirstName + "Changed";
            }
            Console.WriteLine("");
            foreach (var student in studentList)
            {
                Console.WriteLine($"After Modifying Entity State: {context.Entry(student).State}");
            }
            context.SaveChanges();
            Console.WriteLine("");
            foreach (var student in studentList)
            {
                Console.WriteLine($"After SaveChanges Entity State: {context.Entry(student).State}");
            }*/

            //INSERT List
            /*List<Student> students = new List<Student>
            {
               new Student(){ FirstName="Test1", LastName="Test11", StandardId=1},
               new Student(){ FirstName="Test2", LastName="Test22", StandardId=2},
               new Student(){ FirstName="Test3", LastName="Test33", StandardId=3}
            };
            context.Students.AddRange(students);
            foreach (var student in students)
            {
                Console.WriteLine($"Before SaveChanges Entity State: {context.Entry(student).State}");
            }
            context.SaveChanges();
            foreach (var student in students)
            {
                Console.WriteLine($"After SaveChanges Entity State: {context.Entry(student).State}");
            }*/

            //INSERT
            /*var student = new Student
            {
                FirstName = "Hina",
                LastName = "Sharma",
                StandardId = 1
            };
            context.Students.Add(student);
            Console.WriteLine($"Before SaveChanges Entity State: {context.Entry(student).State}");

            context.SaveChanges();
            Console.WriteLine($"After SaveChanges Entity State: {context.Entry(student).State}");*/

            //READ
            /*List<Student> listStudents = context.Students.ToList();
            foreach (Student student in listStudents)
            {
                Console.WriteLine($" Name = {student.FirstName} {student.LastName}, Email {student.StudentAddress?.Email}, Mobile {student.StudentAddress?.Mobile}");
            }*/
            Console.ReadKey();
        }
    }
}
