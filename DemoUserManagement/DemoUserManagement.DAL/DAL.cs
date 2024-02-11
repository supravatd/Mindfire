using DemoUserManagement.Models;
using StudentLayers.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoUserManagement.DAL
{
    public class DAL
    {
        public static List<Country> GetCountry()
        {
            List<Country> countryList = new List<Country>();
            try
            {
                using (DemoUserManagementEntities context = new DemoUserManagementEntities())
                {
                    countryList = context.Countries.ToList();
                }
            }
            catch (Exception e)
            {
                Logger.AddData(e);
            }
            return countryList;
        }

        public static List<State> GetState()
        {
            List<State> stateList = new List<State>();
            try
            {
                using (DemoUserManagementEntities context = new DemoUserManagementEntities())
                {
                    stateList = context.States.ToList();
                }
            }
            catch (Exception e)
            {
                Logger.AddData(e);
            }
            return stateList;
        }

        public static List<State> StateCountry(int countryId)
        {
            List<State> stateList = new List<State>();
            try
            {
                using (DemoUserManagementEntities context = new DemoUserManagementEntities())
                {
                    stateList = context.States.Where(states => states.CountryID == countryId).ToList();
                }
            }
            catch (Exception e)
            {
                Logger.AddData(e);
            }
            return stateList;
        }

        public static void SaveUser(UserModel userModel)
        {
            using (DemoUserManagementEntities context = new DemoUserManagementEntities())
            {
                // Create and save user entity
                UserDetail user = new UserDetail
                {
                    FirstName = userModel.FirstName,
                    MiddleName = userModel.MiddleName,
                    LastName = userModel.LastName,
                    FatherFirstName = userModel.FatherFirstName,
                    FatherMiddleName = userModel.FatherMiddleName,
                    FatherLastName = userModel.FatherLastName,
                    MotherFirstName = userModel.MotherFirstName,
                    MotherMiddleName = userModel.MotherMiddleName,
                    MotherLastName = userModel.MotherLastName,
                    Email = userModel.Email,
                    Dob= DateTime.Parse(userModel.Dob),
                    BloodGroup=userModel.BloodGroup,
                    MobileNo=userModel.MobileNo,
                    IDType=userModel.IDType,
                    IDNo=userModel.IDNo,
                    Gender=userModel.Gender,
                    Hobbies=userModel.Hobbies
                };
                context.UserDetails.Add(user);
                context.SaveChanges();
            }
        }
        public static void SaveAddress(AddressModel address)
        {
            using (DemoUserManagementEntities context = new DemoUserManagementEntities())
            {
                Address user = new Address
                {
                    AddressType = address.Type,
                    DoorNo = address.DoorNo,
                    Street = address.Street,
                    City = address.City,
                    PostalCode = address.PostalCode,
                    Country = address.Country,
                    State = address.State,
                    
                };
                context.Addresses.Add(user);
                context.SaveChanges();
            }
        }
        public static void UpdateUser(int userId, UserModel userModel)
        {
            using (DemoUserManagementEntities context = new DemoUserManagementEntities())
            {
                UserDetail user = context.UserDetails.FirstOrDefault(x => x.UserId == userId);
                if (user != null)
                {
                    // Manually map properties from UserModel to User entity
                    user.FirstName = userModel.FirstName;
                    user.MiddleName = userModel.MiddleName;
                    user.LastName = userModel.LastName;
                    user.FatherFirstName = userModel.FatherFirstName;
                    user.FatherMiddleName = userModel.FatherMiddleName;
                    user.FatherLastName = userModel.FatherLastName;
                    user.MotherFirstName = userModel.MotherFirstName;
                    user.MotherMiddleName = userModel.MotherMiddleName;
                    user.MotherLastName = userModel.MotherLastName;
                    user.Email = userModel.Email;
                    user.Dob = DateTime.ParseExact(userModel.Dob, "D", null);
                    user.BloodGroup = userModel.BloodGroup;
                    user.MobileNo = userModel.MobileNo;
                    user.IDType = userModel.IDType;
                    user.IDNo = userModel.IDNo;
                    user.Gender = userModel.Gender;
                    user.Hobbies = userModel.Hobbies;

                    context.SaveChanges();
                }
            }
        }

        public static void DeleteUser(int userId)
        {
            using (DemoUserManagementEntities context = new DemoUserManagementEntities())
            {
                UserDetail user = context.UserDetails.FirstOrDefault(x => x.UserId == userId);
                if (user != null)
                {
                    context.UserDetails.Remove(user);
                    context.SaveChanges();
                }
            }
        }
    }
}
