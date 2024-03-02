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
    public class UsersDAL
    {
        string conn = ConfigurationManager.ConnectionStrings["users"].ConnectionString;
        public List<UserModel> GetAllUsers(int pageIndex, int pageSize, string sortBy)
        {
            using (var context = new DemoUserManagementEntities())
            {
                var query = context.UserDetails.AsQueryable();

                switch (sortBy)
                {
                    case "UserId":
                        query = query.OrderBy(u => u.UserId);
                        break;
                    case "FirstName":
                        query = query.OrderBy(u => u.FirstName);
                        break;
                    case "LastName":
                        query = query.OrderBy(u => u.LastName);
                        break;
                    case "Email":
                        query = query.OrderBy(u => u.Email);
                        break;
                    default:
                        query = query.OrderBy(u => u.UserId);
                        break;
                }

                var users = query.Skip((pageIndex - 1) * pageSize)
                                .Take(pageSize)
                                .Select(u => new UserModel
                                {
                                    UserId = u.UserId,
                                    FirstName = u.FirstName,
                                    LastName = u.LastName,
                                    Email = u.Email,
                                    Dob = u.Dob,
                                    MobileNo = u.MobileNo,
                                    IDType = u.IDType,
                                    IDNo = u.IDNo,
                                    Gender = u.Gender,
                                    Hobbies = u.Hobbies,
                                    FileGuid = u.FileGuid,
                                    FileOriginal = u.FileOriginal,
                                }).ToList();
                return users;
            }
        }


        public int GetTotalUsers()
        {
            using (var context = new DemoUserManagementEntities())
            {
                return context.UserDetails.Count();
            }
        }

        public UserModel GetUserById(int userId)
        {
            UserModel user = null;

            using (var context = new DemoUserManagementEntities())
            {
                user = context.UserDetails.Where(u => u.UserId == userId).Select(u => new UserModel
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
                    Password = u.Password,
                    BloodGroup = u.BloodGroup,
                    MobileNo = u.MobileNo,
                    IDType = u.IDType,
                    IDNo = u.IDNo,
                    Gender = u.Gender,
                    Hobbies = u.Hobbies,
                    Dob = u.Dob,
                    FileGuid = u.FileGuid,
                    FileOriginal = u.FileOriginal,
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


