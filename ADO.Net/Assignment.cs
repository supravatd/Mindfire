using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace ADO.Net
{
    internal class Assignment
    {
        static string cs = ConfigurationManager.ConnectionStrings["db1"].ConnectionString;

        static void Main()
        {
            try
            {
                InsertData();
                ReadData();
                UpdateData();
                DeleteData();
            }
            catch (Exception ex)
            {
                LogError(ex.Message);
            }
        }

        private static void InsertData()
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                Console.WriteLine("Employee Id: ");
                string id = Console.ReadLine();
                Console.WriteLine("Employee Name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Manager Id: ");
                string manager = Console.ReadLine();
                Console.WriteLine("DOB: ");
                string dob = Console.ReadLine();
                Console.WriteLine("Hire Date: ");
                string hire = Console.ReadLine();
                Console.WriteLine("Job Title: ");
                string title = Console.ReadLine();
                Console.WriteLine("Salary: ");
                string sal = Console.ReadLine();
                Console.WriteLine("Department: ");
                string dept = Console.ReadLine();

                string insertQuery = "INSERT INTO employees VALUES (@id, @name, @manager, @dob, @hire, @title, @sal, @dept)";
                using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@manager", manager);
                    cmd.Parameters.AddWithValue("@dob", dob);
                    cmd.Parameters.AddWithValue("@hire", hire);
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@sal", sal);
                    cmd.Parameters.AddWithValue("@dept", dept);

                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        Console.WriteLine("Data inserted");
                    }
                    else
                    {
                        Console.WriteLine("Insertion Failed");
                    }
                    Console.ReadLine();
                }
            }
        }

        private static void ReadData()
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string selectQuery = "SELECT * FROM employees";
                using (SqlCommand com = new SqlCommand(selectQuery, conn))
                {
                    conn.Open();
                    using (SqlDataReader dr = com.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Console.WriteLine(dr["Employee_Id"] + "," + dr["Employee_Name"] + "," + dr["Manager_Id"]);
                        }
                        Console.ReadLine();
                    }
                }
            }
        }

        private static void UpdateData()
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                Console.WriteLine("Employee Id: ");
                string id = Console.ReadLine();
                Console.WriteLine("Employee Name: ");
                string name = Console.ReadLine();

                string updateQuery = "UPDATE employees SET Employee_Name=@name WHERE Employee_Id=@id";
                using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", name);

                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        Console.WriteLine("Data Updated");
                    }
                    else
                    {
                        Console.WriteLine("Update Failed");
                    }
                    Console.ReadLine();
                }
            }
        }

        private static void DeleteData()
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                Console.WriteLine("Employee Id: ");
                string id = Console.ReadLine();

                string deleteQuery = "DELETE FROM employees WHERE Employee_ID=@id";
                using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        Console.WriteLine("Data Deleted");
                    }
                    else
                    {
                        Console.WriteLine("Delete Failed");
                    }
                    Console.ReadLine();
                }
            }
        }

        private static void LogError(string errorMessage)
        {
            string logFileName = $"error_log_{DateTime.Now:yyyyMMdd}.txt";
            string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, logFileName);

            if (!File.Exists(logFilePath))
            {
                using (StreamWriter sw = File.CreateText(logFilePath))
                {
                    sw.WriteLine($"Log created on {DateTime.Now}");
                }
            }

            // Append the error to the existing log file
            using (StreamWriter sw = File.AppendText(logFilePath))
            {
                sw.WriteLine($"[{DateTime.Now}] {errorMessage}");
            }
        }
    }
}
