using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ADONET
{
    class DataAdapter
    {
        static void Main(string[] args)
        {
            string cs = ConfigurationManager.ConnectionStrings["db1"].ConnectionString;
            SqlConnection conn = new SqlConnection(cs);
            SqlDataAdapter sda = new SqlDataAdapter("select * from employees", conn);
            DataSet ds = new DataSet();
            sda.Fill(ds);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7}", row[0], row[1], row[2], row[3], row[4], row[5], row[6], row[7]);
            }
            Console.ReadLine();
            Console.WriteLine("------------");
            DataTable dt = new DataTable();
            sda.Fill(dt);

            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7}", row[0], row[1], row[2], row[3], row[4], row[5], row[6], row[7]);
            }
            Console.ReadLine();
        }
    }
}
