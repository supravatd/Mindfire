using DemoUserManagement.DAL;
using DemoUserManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DemoUserManagement.Models.Model;

namespace DemoUserManagement.Business
{
    public class Business
    {
        public static List<CountryModel> GetCountryList()
        {
            List<Country> countries = DAL.DAL.GetCountry();
            List<CountryModel> countryList = countries.Select(country => new CountryModel
            {
                CountryId = country.CountryID,
                CountryName = country.CountryName
            }).ToList();

            return countryList;
        }

        public static List<StateModel> GetStateList(string countryName)
        {
            List<State> states = DAL.DAL.GetState(countryName);
            List<StateModel> stateList = states.Select(state => new StateModel
            {
                StateId = state.StateID,
                StateName = state.StateName
            }).ToList();

            return stateList;
        }


        public void AddUserAddress(UserModel userModel, AddressModel presentAddress, AddressModel permanentAddress)
        {
            int userId = DAL.DAL.SaveUser(userModel);
            presentAddress.UserId = userId;
            DAL.DAL.SaveAddress(presentAddress);
            permanentAddress.UserId = userId;
            DAL.DAL.SaveAddress(permanentAddress);
        }

        public static void UpdateUser(int userId, UserModel userModel)
        {
            DAL.Update.UpdateUser(userId, userModel);
        }

        public List<UserModel> GetAllUsers()
        {
            DAL.GetAllUsers user = new DAL.GetAllUsers();
            return user.Users();
        }

        public UserModel GetUserById(string userId)
        {
            DAL.GetAllUsers user = new DAL.GetAllUsers();
            return user.GetUserById(userId);
        }

        public void AddNote(NoteModel note)
        {
            DAL.DAL noteDAL = new DAL.DAL();
            noteDAL.AddNote(note);
        }

        public List<NoteModel> GetAllNotes()
        {
            List<NoteModel> notes = new List<NoteModel>();
            DAL.DAL noteDAL = new DAL.DAL();
            notes = noteDAL.GetAllNotes();
            return notes;
        }
    }
}

