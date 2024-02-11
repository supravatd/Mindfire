using DemoUserManagement.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoUserManagement.DAL
{
    public class GetAllUsers
    {
        string conn = ConfigurationManager.ConnectionStrings["users"].ConnectionString;
        public List<UserModel> Users()
        {
            List<UserModel> users = new List<UserModel>();
            using (SqlConnection connection = new SqlConnection(conn))
            {
                string query = "SELECT * FROM UserDetails";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            UserModel user = new UserModel();
                            user.FirstName = reader["FirstName"].ToString();
                            user.LastName = reader["LastName"].ToString();
                            user.FatherFirstName = reader["FatherFirstName"].ToString();
                            user.MotherFirstName = reader["MotherFirstName"].ToString();
                            user.Email = reader["Email"].ToString();
                            user.Dob = reader["Dob"].ToString();
                            user.MobileNo = reader["MobileNo"].ToString();
                            user.IDType = reader["IDType"].ToString();
                            user.IDNo = reader["IDNo"].ToString();
                            user.Gender = reader["Gender"].ToString() ;
                            user.Hobbies = reader["Hobbies"].ToString();
                            users.Add(user);
                        }
                    }
                }
            }
            return users;
        }
    }
}
