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
            List<State> states = DAL.DAL.GetState(countryId);
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

        public static List<UserModel> GetAllUsers(int pageIndex, int pageSize)
        {
            UsersDAL usersDAL = new UsersDAL();
            return usersDAL.GetAllUsers(pageIndex, pageSize);
        }

        public static int GetTotalUsers()
        {
            UsersDAL usersDAL = new UsersDAL();
            return usersDAL.GetTotalUsers();
        }

        public int GetTotalNotes(int objectId)
        {
            DAL.NotesDAL notesDAL = new DAL.NotesDAL();
            return notesDAL.GetTotalNotes(objectId);
        }

        public static UserModel GetUserById(int userId)
        {
            UsersDAL user = new UsersDAL();
            return user.GetUserById(userId);
        }

        public void AddNote(NoteModel note)
        {
            DAL.DAL noteDAL = new DAL.DAL();
            noteDAL.AddNote(note);
        }

        public List<NoteModel> GetAllNotes(int pageIndex, int pageSize,int objectId)
        {
            List<NoteModel> notes = new List<NoteModel>();
            DAL.DAL noteDAL = new DAL.DAL();
            notes = noteDAL.GetAllNotes(pageIndex,pageSize,objectId);
            return notes;
        }

        public static void SaveFileToDatabase(int userId,string filename, string guid)
        {
            DAL.DAL.SaveFileToDatabase(userId,filename, guid);
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

        public static List<DocumentModel> GetUploadedDocuments(int pageIndex, int pageSize, int objectId)
        {
            return DAL.DAL.GetDocuments(pageIndex,pageSize,objectId);
        }

        public static int GetTotalDocuments(int objectId)
        {
            return DAL.DAL.GetTotalDocuments(objectId);
        }

        public static int IsUser(string email, string password)
        {
            throw new NotImplementedException();
        }

        public static bool IsAdmin(int isuser)
        {
            throw new NotImplementedException();
        }
    }
}

