using DemoUserManagement.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
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
            UserModel user = null;
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
                            user = new UserModel()
                            {
                                UserId = (int)reader["UserId"],
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                FatherFirstName = reader["FatherFirstName"].ToString(),
                                MotherFirstName = reader["MotherFirstName"].ToString(),
                                Email = reader["Email"].ToString(),
                                Dob = reader["Dob"].ToString(),
                                MobileNo = reader["MobileNo"].ToString(),
                                IDType = reader["IDType"].ToString(),
                                IDNo = reader["IDNo"].ToString(),
                                Gender = reader["Gender"].ToString(),
                                Hobbies = reader["Hobbies"].ToString(),
                            };

                        users.Add(user);
                        }
                    }
                }
            }
            return users;
        }


        public UserModel GetUserById(string userId)
        {
            UserModel user = null;

            using (SqlConnection connection = new SqlConnection(conn))
            {
                string query = @"SELECT u.*, a.*
                                FROM UserDetails u
                                LEFT JOIN Address a ON u.UserId = a.UserId
                                WHERE u.UserId = @UserId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (user == null)
                            {
                                user = new UserModel
                                {
                                    UserId = (int)reader["UserId"],
                                    FirstName = reader["FirstName"].ToString(),
                                    LastName = reader["LastName"].ToString(),
                                    FatherFirstName = reader["FatherFirstName"].ToString(),
                                    FatherMiddleName = reader["FatherMiddleName"].ToString(),
                                    FatherLastName = reader["FatherLastName"].ToString(),
                                    MotherFirstName = reader["MotherFirstName"].ToString(),
                                    MotherMiddleName = reader["MotherMiddleName"].ToString(),
                                    MotherLastName = reader["MotherLastName"].ToString(),
                                    Email = reader["Email"].ToString(),
                                    BloodGroup = reader["BloodGroup"].ToString(),
                                    MobileNo = reader["MobileNo"].ToString(),
                                    IDType = reader["IDType"].ToString(),
                                    IDNo = reader["IDNo"].ToString(),
                                    Gender = reader["Gender"].ToString(),
                                    Hobbies = reader["Hobbies"].ToString(),
                                };
                            }
                            string dobString = reader["Dob"].ToString();
                            DateTime dob;
                            if (DateTime.TryParseExact(dobString, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dob))
                            {
                                user.Dob = dob.ToString();
                            }

                            int addressType;
                            if (reader["AddressType"] != DBNull.Value)
                            {
                                addressType = Convert.ToInt32(reader["AddressType"]);
                            }
                            else
                            {
                                addressType = 0;
                            }
                            if (addressType == 0)
                            {
                                user.PresentAddress = new AddressModel
                                {
                                    DoorNo = reader["DoorNo"].ToString(),
                                    Street = reader["Street"].ToString(),
                                    City = reader["City"].ToString(),
                                    PostalCode = reader["PostalCode"].ToString(),
                                    Country = reader["Country"].ToString(),
                                    State = reader["State"].ToString()
                                };
                            }
                            else if (addressType == 1)
                            {
                                user.PermanentAddress = new AddressModel
                                {
                                    DoorNo = reader["DoorNo"].ToString(),
                                    Street = reader["Street"].ToString(),
                                    City = reader["City"].ToString(),
                                    PostalCode = reader["PostalCode"].ToString(),
                                    Country = reader["Country"].ToString(),
                                    State = reader["State"].ToString()
                                };
                            }
                        }
                    }
                }
            }

            return user;
        }
    }
}

