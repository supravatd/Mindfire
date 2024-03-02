using DemoUserManagement.DAL;
using DemoUserManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DemoUserManagement.DAL.DAL;
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
            List<State> states = DAL.DAL.GetState(countryId);
            List<StateModel> stateList = states.Select(state => new StateModel
            {
                StateId = state.StateID,
                StateName = state.StateName
            }).ToList();

            return stateList;
        }


        public static void AddUserAddress(UserModel userModel, AddressModel presentAddress, AddressModel permanentAddress)
        {
            int userId = DAL.DAL.SaveUser(userModel);
            presentAddress.UserId = userId;
            DAL.DAL.SaveAddress(presentAddress);
            permanentAddress.UserId = userId;
            DAL.DAL.SaveAddress(permanentAddress);
            DAL.DAL.AddRole(userId);
        }

        public static void UpdateUser(int userId, UserModel userModel)
        {
            DAL.Update.UpdateUser(userId, userModel);
        }

        public static int GetUserId(UserModel userModel)
        {
            return DAL.DAL.SaveUser(userModel);
        }

        public static List<UserModel> GetAllUsers(int pageIndex, int pageSize, string sortBy)
        {
            UsersDAL usersDAL = new UsersDAL();
            return usersDAL.GetAllUsers(pageIndex, pageSize, sortBy);
        }

        public static bool IsAdmin(int userId)
        {
            return DAL.DAL.IsAdmin(userId);
        }

        public static int GetTotalUsers()
        {
            UsersDAL usersDAL = new UsersDAL();
            return usersDAL.GetTotalUsers();
        }

        public static int GetTotalNotes(int objectId)
        {
            return NotesDAL.GetTotalNotes(objectId);
        }

        public static UserModel GetUserById(int userId)
        {
            UsersDAL user = new UsersDAL();
            return user.GetUserById(userId);
        }

        public static void AddNote(NoteModel note)
        {
            DAL.DAL noteDAL = new DAL.DAL();
            noteDAL.AddNote(note);
        }

        public static List<NoteModel> GetAllNotes(int pageIndex, int pageSize, int objectId, string sortBy)
        {
            List<NoteModel> notes = new List<NoteModel>();
            notes = DAL.DAL.GetAllNotes(pageIndex, pageSize, objectId, sortBy);
            return notes;
        }

        public static void SaveFileToDatabase(int userId, string filename, string guid)
        {
            DAL.DAL.SaveFileToDatabase(userId, filename, guid);
        }

        public static List<DocumentTypeModel> GetDocumentType()
        {
            List<DocumentType> documentTypes = DAL.DAL.GetDocumentType();
            List<DocumentTypeModel> docType = documentTypes.Select(doc => new DocumentTypeModel
            {
                DocumentTypeID = doc.DocTypeId,
                DocumentTypeName = doc.DocTypeName
            }).ToList();

            return docType;
        }

        public static void AddDocument(DocumentModel doc)
        {
            DAL.DAL.AddDocuments(doc);
        }

        public static List<DocumentModel> GetUploadedDocuments(int pageIndex, int pageSize, int objectId, string sortBy)
        {
            return DAL.DAL.GetDocuments(pageIndex, pageSize, objectId, sortBy);
        }

        public static int GetTotalDocuments(int objectId)
        {
            return DAL.DAL.GetTotalDocuments(objectId);
        }

        public static int IsUser(string email, string password)
        {
            return DAL.DAL.IsUser(email, password);
        }

        public static bool EmailExists(string email)
        {
            return DAL.DAL.EmailExists(email);
        }

        public static bool CheckUserEmail(string userId, string email)
        {
            return DAL.DAL.UserEmail(userId, email);
        }
    }
}

