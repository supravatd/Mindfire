using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using ADONet.Tools;


namespace ADONET
{
    class DataAdapter
    {
        static void Main(string[] args)
        {
            string cs = ConfigurationManager.ConnectionStrings["db1"].ConnectionString;
            SqlConnection conn = new SqlConnection(cs);
            SqlDataAdapter sda = new SqlDataAdapter("select * from employees", conn);

            //DataTable to List
            DataTable dt = new DataTable("employees");
            sda.Fill(dt);
            List<Employees> dataList = dt.ToList<Employees>();
            Console.WriteLine($"{dataList.GetType()}");
            foreach (DataColumn column in dt.Columns)
            {
                Console.Write($"{column.ColumnName}\t");
            }
            Console.WriteLine();
            foreach (Employees employee in dataList)
            {
                Console.WriteLine($"{employee.Employee_Id}\t{employee.Employee_Name}\t{employee.Manager_Id}\t{employee.DateOfBirth}\t{employee.HireDate}\t{employee.Job_title}\t{employee.Salary}\t{employee.Department}");
            }

            Console.WriteLine("------------");

            //List to DataTable
            DataTable newdt = dataList.ToDataTable("Convertedtable");
            Console.WriteLine($"{newdt.GetType()}");
            foreach (DataRow row in newdt.Rows)
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7}", row[0], row[1], row[2], row[3], row[4], row[5], row[6], row[7]);
            }
            Console.ReadLine();
        }
    }

    public class Employees
    {
        public string Employee_Name { get; set; }
        public int Employee_Id { get; set;}
        public int Manager_Id { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime HireDate { get; set; }
        public string Job_title { get; set; }
        public decimal Salary { get; set; }
        public string Department { get; set; }
    }
}
