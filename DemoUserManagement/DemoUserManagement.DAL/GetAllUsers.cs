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
            List<UserModel> users;

            using (var context = new DemoUserManagementEntities())
            {
                users = context.UserDetails.Select(u => new UserModel
                {
                    UserId = u.UserId,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    FatherFirstName = u.FatherFirstName,
                    MotherFirstName = u.MotherFirstName,
                    Email = u.Email,
                    Dob = u.Dob,
                    MobileNo = u.MobileNo,
                    IDType = u.IDType,
                    IDNo = u.IDNo,
                    Gender = u.Gender,
                    Hobbies = u.Hobbies
                }).ToList();
            }

            return users;
        }

        public UserModel GetUserById(string userId)
        {
            UserModel user = null;

            using (var context = new DemoUserManagementEntities())
            {
                user = context.UserDetails.Where(u => u.UserId.ToString() == userId).Select(u => new UserModel
                {
                    UserId = u.UserId,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    FatherFirstName = u.FatherFirstName,
                    FatherMiddleName = u.FatherMiddleName,
                    FatherLastName = u.FatherLastName,
                    MotherFirstName = u.MotherFirstName,
                    MotherMiddleName = u.MotherMiddleName,
                    MotherLastName = u.MotherLastName,
                    Email = u.Email,
                    BloodGroup = u.BloodGroup,
                    MobileNo = u.MobileNo,
                    IDType = u.IDType,
                    IDNo = u.IDNo,
                    Gender = u.Gender,
                    Hobbies = u.Hobbies,
                    Dob = u.Dob,
                    PresentAddress = u.Addresses.Where(a => a.AddressType == 0).Select(a => new AddressModel
                    {
                        DoorNo = a.DoorNo,
                        Street = a.Street,
                        City = a.City,
                        PostalCode = a.PostalCode,
                        CountryId = (int)a.CountryId,
                        StateId = (int)a.StateId
                    }).FirstOrDefault(),
                    PermanentAddress = u.Addresses.Where(a => a.AddressType == 1).Select(a => new AddressModel
                    {
                        DoorNo = a.DoorNo,
                        Street = a.Street,
                        City = a.City,
                        PostalCode = a.PostalCode,
                        CountryId = (int)a.CountryId,
                        StateId = (int)a.StateId
                    }).FirstOrDefault()
                })
                    .FirstOrDefault();
            }
            return user;
        }
    }
}

