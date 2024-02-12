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

        public static List<State> GetState(string countryName)
        {
            List<State> stateList = new List<State>();
            try
            {
                using (DemoUserManagementEntities context = new DemoUserManagementEntities())
                {
                    stateList = context.States.Where(s => s.Country.CountryName == countryName).ToList();
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

        public static int SaveUser(UserModel userModel)
        {
            int userId = 0;
            using (DemoUserManagementEntities context = new DemoUserManagementEntities())
            {
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
                    Dob = DateTime.Parse(userModel.Dob),
                    BloodGroup = userModel.BloodGroup,
                    MobileNo = userModel.MobileNo,
                    IDType = userModel.IDType,
                    IDNo = userModel.IDNo,
                    Gender = userModel.Gender,
                    Hobbies = userModel.Hobbies
                };
                context.UserDetails.Add(user);
                context.SaveChanges();
                userId = user.UserId;
            }
            return userId;
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
                    UserId = address.UserId,
                };
                context.Addresses.Add(user);
                context.SaveChanges();
            }
        }

        public void AddNote(NoteModel note)
        {
            using (var context = new DemoUserManagementEntities())
            {
                Note noteEntity = new Note
                {
                    UserID=note.UserId,
                    NoteData = note.NoteData,
                    PageName = note.PageName,
                    DateTimeAdded = DateTime.Now
                };

                context.Notes.Add(noteEntity);
                context.SaveChanges();
            }
        }

        public List<NoteModel> GetAllNotes()
        {
            List<NoteModel> notes = new List<NoteModel>();

            using (var context = new DemoUserManagementEntities())
            {
                var noteEntities = context.Notes.ToList();
                foreach (var noteEntity in noteEntities)
                {
                    NoteModel noteModel = new NoteModel
                    {
                        NoteId=noteEntity.NoteID,
                        NoteData = noteEntity.NoteData,
                        UserId = noteEntity.UserID != null ? (int)noteEntity.UserID : 0,
                        PageName = noteEntity.PageName,
                        DateTimeAdded = noteEntity.DateTimeAdded.ToString()
                    };

                    notes.Add(noteModel);
                }
                return notes;
            }
        }
    }
}
