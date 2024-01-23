using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace ADONet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program.Connection();
            Console.ReadLine();
        }
        static void Connection()
        {
            string cs = ConfigurationManager.ConnectionStrings["db1"].ConnectionString;
            SqlConnection conn = null;
            try
            {
                using (conn = new SqlConnection(cs))
                {
                    //Execute Scalar 
                    string query = "select max(Salary) from employees";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    int a = Convert.ToInt32(cmd.ExecuteScalar());
                    Console.WriteLine(a);

                    //Delete in db
                    /*Console.WriteLine("Employee Id: ");
                    string id = Console.ReadLine();
                    string query = "delete from employees where Employee_ID=@id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    conn.Open();
                    int a = cmd.ExecuteNonQuery();
                    if (a > 0)
                    {
                        Console.WriteLine("Data Deleted");
                    }
                    else
                    {
                        Console.WriteLine("Delete Failed");
                    }*/



                    //Update in db
                    /*Console.WriteLine("Employee Id: ");
                    string id = Console.ReadLine();
                    Console.WriteLine("Employee Name: ");
                    string name = Console.ReadLine();

                    string query = "update employees set Employee_Name=@name where Employee_Id=@id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", name);

                    conn.Open();
                    int a = cmd.ExecuteNonQuery();
                    if (a > 0)
                    {
                        Console.WriteLine("Data Updated");
                    }
                    else
                    {
                        Console.WriteLine("Update Failed");
                    }*/

                    //Insert into db
                    /*Console.WriteLine("Employee Id: ");
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

                    string query = "insert into employees values(@id,@name,@manager,@dob,@hire,@title,@sal,@dept
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@manager", manager);
                    cmd.Parameters.AddWithValue("@dob", dob);
                    cmd.Parameters.AddWithValue("@hire", hire);
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@sal", sal);
                    cmd.Parameters.AddWithValue("@dept", dept);

                    conn.Open();
                    int a = cmd.ExecuteNonQuery();
                    if (a > 0)
                    {
                        Console.WriteLine("Data inserted");
                    }
                    else
                    {
                        Console.WriteLine("Insertion Failed");
                    }*/


                    //Can also be done like this
                    /*string query = "SelectAllEmployees";
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText=query;
                    cmd.Connection=conn;
                    cmd.ComandType=CommandType.StoredProcedure;*/

                    //Execute Reader
                    /*SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Console.WriteLine(dr["Employee_Id"] + "," + dr["Employee_Name"] + "," + dr["Manager_Id"]);
                    }
                    */

                    //Create a table
                    //SqlCommand cm = new SqlCommand("create table student(id int not null, name varchar(100), email varchar(50), join_date date)", con);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
