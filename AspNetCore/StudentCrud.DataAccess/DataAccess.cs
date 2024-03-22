using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StudentCrud.DataAccess.Models;
using StudentCrud.Models;
using StudentCrud.Utils;

namespace StudentCrud.DataAccess
{
    public class DataAccess : IDataAccess
    {
        private readonly PracticeContext context;

        private readonly Utils.ILogger logger;

        public DataAccess(PracticeContext context, Utils.ILogger logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public async Task<bool> UpdateData(StudentModel s)
        {
            bool flag = false;
            try
            {
                using (var transaction = await context.Database.BeginTransactionAsync())
                {
                    var studentToUpdate = await context.Employees.FirstOrDefaultAsync(stu => stu.EmployeeId == s.StudentId);
                    if (studentToUpdate != null)
                    {
                        studentToUpdate.FirstName = s.FirstName;
                        studentToUpdate.LastName = s.LastName;
                        studentToUpdate.EmailAddress = s.Email;
                        studentToUpdate.Salary = s.Salary;

                        await context.SaveChangesAsync();
                        await transaction.CommitAsync();
                        flag = true;
                    }
                    else
                    {
                        await transaction.RollbackAsync();
                    }
                    logger.AddException(new Exception("Hello"));
                }
            }
            catch (Exception ex)
            {
                logger.AddException(ex);
            }
            return flag;
        }

        public async Task<bool> DeleteData(StudentModel s)
        {
            bool flag = false;
            try
            {
                using (var transaction = await context.Database.BeginTransactionAsync())
                {
                    var studentToUpdate = await context.Employees.FirstOrDefaultAsync(stu => stu.EmployeeId == s.StudentId);
                    if (studentToUpdate != null)
                    {
                        context.Employees.Remove(studentToUpdate);
                        await context.SaveChangesAsync();
                        await transaction.CommitAsync();
                        flag = true;
                    }
                    else
                    {
                        await transaction.RollbackAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.AddException(ex);
            }
            return flag;
        }

        public async Task<bool> AddData(StudentModel s)
        {
            bool flag = false;
            try
            {
                using (var transaction = await context.Database.BeginTransactionAsync())
                {
                    try
                    {
                        var newStudent = new Employee
                        {
                            FirstName = s.FirstName,
                            LastName = s.LastName,
                            EmailAddress = s.Email,
                            Salary = s.Salary
                        };
                        await context.Employees.AddAsync(newStudent);
                        await context.SaveChangesAsync();
                        await transaction.CommitAsync();
                        flag = true;
                    }
                    catch (Exception ex)
                    {
                        await transaction.RollbackAsync();
                        logger.AddException(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.AddException(ex);
            }
            return flag;
        }

        public async Task<List<StudentModel>> ListData()
        {
            var alldata = new List<StudentModel>();

            try
            {
                var result = await context.Employees.ToListAsync();

                foreach (var student in result)
                {
                    alldata.Add(new StudentModel
                    {
                        FirstName = student.FirstName,
                        LastName = student.LastName,
                        Email = student.EmailAddress,
                        Salary = (int?)student.Salary,
                        StudentId = student.EmployeeId
                    });
                }
            }
            catch (Exception ex)
            {
                logger.AddException(ex);
            }

            return alldata;
        }

        public string GettestData()
        {
            return DateTime.Now.ToString();
        }
    }
}