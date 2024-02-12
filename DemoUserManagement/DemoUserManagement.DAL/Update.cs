using AutoMapper;
using DemoUserManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoUserManagement.DAL
{
    public class Update
    {
        public static void UpdateUser(int userId, UserModel userModel)
        {
            using (DemoUserManagementEntities context = new DemoUserManagementEntities())
            {
                UserDetail user = context.UserDetails.Find(userId);

                if (user != null)
                {
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
                    user.Dob = DateTime.Parse(userModel.Dob);
                    user.BloodGroup = userModel.BloodGroup;
                    user.MobileNo = userModel.MobileNo;
                    user.IDType = userModel.IDType;
                    user.IDNo = userModel.IDNo;
                    user.Gender = userModel.Gender;
                    user.Hobbies = userModel.Hobbies;

                    Address presentAddress = user.Addresses.FirstOrDefault(a => a.AddressType == 0);
                    if (presentAddress != null)
                    {
                        presentAddress.DoorNo = userModel.PresentAddress.DoorNo;
                        presentAddress.Street = userModel.PresentAddress.Street;
                        presentAddress.City = userModel.PresentAddress.City;
                        presentAddress.PostalCode = userModel.PresentAddress.PostalCode;
                        presentAddress.Country = userModel.PresentAddress.Country;
                        presentAddress.State = userModel.PresentAddress.State;
                    }
                }

                Address permanentAddress = user.Addresses.FirstOrDefault(a => a.AddressType == 1);
                if (permanentAddress != null)
                {
                    permanentAddress.DoorNo = userModel.PermanentAddress.DoorNo;
                    permanentAddress.Street = userModel.PermanentAddress.Street;
                    permanentAddress.City = userModel.PermanentAddress.City;
                    permanentAddress.PostalCode = userModel.PermanentAddress.PostalCode;
                    permanentAddress.Country = userModel.PermanentAddress.Country;
                    permanentAddress.State = userModel.PermanentAddress.State;
                }

                context.SaveChanges();
            }
        }

        
    }
}
