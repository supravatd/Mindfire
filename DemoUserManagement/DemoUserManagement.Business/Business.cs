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

        public static List<StateModel> GetStateList(int countryId)
        {
            List<State> states = DAL.DAL.StateCountry(countryId);
            List<StateModel> stateList = states.Select(state => new StateModel
            {
                StateId = state.StateID,
                StateName = state.StateName,
                CountryId = (int)state.CountryID
            }).ToList();

            return stateList;
        }

        public static void SubmitUser(UserModel userModel)
        { 
            DAL.DAL.SaveUser(userModel);
        }

        public static void UpdateUser(int userId,UserModel userModel)
        {
            DAL.Update.UpdateUser(userId, userModel);
        }

        public static void DeleteUser(int userId)
        {
            DAL.Update.DeleteUser(userId);
        }

        public List<UserModel> GetAllUsers()
        {
            DAL.GetAllUsers user=new DAL.GetAllUsers();
            return user.Users();
        }
    }
}

