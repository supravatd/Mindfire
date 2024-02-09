using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practise
{
    internal class LinqPractise
    {
        static void Main(string[] args)
        {
            using(PracticeEntities context=new PracticeEntities())
            {
                List<Employee> salary = context.Employees
                                            .Include("Department")
                                            .Where(e => e.Salary > 70000)
                                            .ToList();
                foreach (Employee employee in salary)
                {
                    Console.WriteLine($"Name: {employee.First_Name} {employee.Last_Name}, Salary: {employee.Salary}, Department Name:{employee.Department.Department_Name}");
                }

                var salary1 = context.Employees
                   .Where(e => e.Salary > 70000)
                   .Join(context.Departments,
                         employee => employee.Department_ID,
                         department => department.Department_ID,
                         (employee, department) => new
                         {
                             employee.First_Name,
                             employee.Last_Name,
                             employee.Salary,
                             department.Department_Name
                         });

                foreach (var employee in salary1)
                {
                    Console.WriteLine($"Name: {employee.First_Name} {employee.Last_Name}, Salary: {employee.Salary}, Department Name: {employee.Department_Name}");
                }

            }
            Console.ReadLine();
        }
    }
}
