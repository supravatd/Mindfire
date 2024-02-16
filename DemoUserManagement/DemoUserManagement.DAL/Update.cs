using AutoMapper;
using DemoUserManagement.Models;
using StudentLayers.Utils;
using System;
using System.Collections.Generic;
using System.IO;
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
                    user.Dob = (DateTime)userModel.Dob;
                    user.BloodGroup = userModel.BloodGroup;
                    user.MobileNo = userModel.MobileNo;
                    user.IDType = userModel.IDType;
                    user.IDNo = userModel.IDNo;
                    user.Gender = userModel.Gender;
                    user.Hobbies = userModel.Hobbies;
                    user.FileGuid = userModel.FileGuid;
                    user.FileOriginal = userModel.FileOriginal;

                    Address presentAddress = user.Addresses.FirstOrDefault(a => a.AddressType == 0);
                    if (presentAddress == null)
                    {
                        presentAddress = new Address();
                        presentAddress.AddressType = 0;
                        user.Addresses.Add(presentAddress);
                    }
                    presentAddress.DoorNo = userModel.PresentAddress.DoorNo;
                    presentAddress.Street = userModel.PresentAddress.Street;
                    presentAddress.City = userModel.PresentAddress.City;
                    presentAddress.PostalCode = userModel.PresentAddress.PostalCode;
                    presentAddress.CountryId = userModel.PresentAddress.CountryId;
                    presentAddress.StateId = userModel.PresentAddress.StateId;

                    Address permanentAddress = user.Addresses.FirstOrDefault(a => a.AddressType == 1);
                    if (permanentAddress == null)
                    {
                        permanentAddress = new Address();
                        permanentAddress.AddressType = 1;
                        user.Addresses.Add(permanentAddress);
                    }
                    permanentAddress.DoorNo = userModel.PermanentAddress.DoorNo;
                    permanentAddress.Street = userModel.PermanentAddress.Street;
                    permanentAddress.City = userModel.PermanentAddress.City;
                    permanentAddress.PostalCode = userModel.PermanentAddress.PostalCode;
                    permanentAddress.CountryId = userModel.PermanentAddress.CountryId;
                    permanentAddress.StateId = userModel.PermanentAddress.StateId;

                    context.SaveChanges();
                }
            }
        }

    }
}
