using DemoUserManagement.Models;
using StudentLayers.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using static DemoUserManagement.Models.Model;
using static DemoUserManagement.Utils.Utils;

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

        public static List<State> GetState(int countryId)
        {
            List<State> stateList = new List<State>();
            try
            {
                using (DemoUserManagementEntities context = new DemoUserManagementEntities())
                {
                    stateList = context.States.Where(s => s.CountryID == countryId).ToList();
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
                    Dob = (DateTime)userModel.Dob,
                    BloodGroup = userModel.BloodGroup,
                    MobileNo = userModel.MobileNo,
                    IDType = userModel.IDType,
                    IDNo = userModel.IDNo,
                    Gender = userModel.Gender,
                    Hobbies = userModel.Hobbies,
                    FileGuid = userModel.FileGuid,
                    FileOriginal = userModel.FileOriginal,
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
                    CountryId = address.CountryId,
                    StateId = address.StateId,
                    UserId = address.UserId,
                };
                context.Addresses.Add(user);
                context.SaveChanges();
            }
        }
        public static void AddRole(int userId)
        {
            using (DemoUserManagementEntities context = new DemoUserManagementEntities())
            {
                var defaultRole = context.Roles.FirstOrDefault(r => r.IsDefault == "True");

                if (defaultRole != null)
                {
                    var userRole = new UserRole
                    {
                        UserId = userId,
                        RoleID = defaultRole.RoleId
                    };
                    context.UserRoles.Add(userRole);
                    context.SaveChanges();
                }
            }
        }

        public void AddNote(NoteModel note)
        {
            using (var context = new DemoUserManagementEntities())
            {
                Note noteEntity = new Note
                {
                    ObjectID = note.ObjectId,
                    NoteData = note.NoteData,
                    ObjectType = note.ObjectType,
                    DateTimeAdded = DateTime.Now
                };

                context.Notes.Add(noteEntity);
                context.SaveChanges();
            }
        }
        public static List<NoteModel> GetAllNotes(int pageIndex, int pageSize, int objectId)
        {
            List<NoteModel> notes = new List<NoteModel>();

            using (var context = new DemoUserManagementEntities())
            {
                notes = context.Notes
                    .Where(n => n.ObjectID == objectId)
                    .OrderBy(n => n.NoteID)
                    .Skip(pageIndex * pageSize)
                    .Take(pageSize)
                    .Select(n => new NoteModel
                    {
                        NoteId = (int)n.NoteID,
                        NoteData = n.NoteData,
                        ObjectId = n.ObjectID,
                        ObjectType = (int)n.ObjectType,
                        DateTimeAdded = n.DateTimeAdded.ToString()
                    })
                    .ToList();
            }
            return notes;
        }
        public static void SaveFileToDatabase(int userId, string filename, string guid)
        {
            using (var context = new DemoUserManagementEntities())
            {
                if (!Guid.TryParse(guid, out Guid guidValue))
                {
                    throw new ArgumentException("Invalid GUID format", nameof(guid));
                }

                var user = context.UserDetails.Find(userId);

                if (user != null)
                {
                    user.FileGuid = guid;
                    user.FileOriginal = filename;
                    context.SaveChanges();
                }
                else
                {
                    throw new ArgumentException("User not found", nameof(userId));
                }
            }
        }

        public static List<DocumentType> GetDocumentType()
        {
            List<DocumentType> docTypeList = new List<DocumentType>();
            try
            {
                using (DemoUserManagementEntities context = new DemoUserManagementEntities())
                {
                    docTypeList = context.DocumentTypes.ToList();
                }
            }
            catch (Exception e)
            {
                Logger.AddData(e);
            }
            return docTypeList;
        }

        public static void AddDocuments(DocumentModel document)
        {
            using (var context = new DemoUserManagementEntities())
            {
                Document docEntity = new Document
                {
                    ObjectId = document.ObjectID,
                    ObjectType = document.ObjectType,
                    DocType = document.DocumentType,
                    DocNameOnDisk = document.DocumnetNameOnDisk,
                    DocOriginalName = document.DocumentOriginalName,
                    Addedon = DateTime.Now
                };

                context.Documents.Add(docEntity);
                context.SaveChanges();
            }
        }

        public static List<DocumentModel> GetDocuments(int pageIndex, int pageSize, int objectId)
        {
            List<DocumentModel> documents = new List<DocumentModel>();

            using (var context = new DemoUserManagementEntities())
            {
                documents = context.Documents
                    .Where(n => n.ObjectId == objectId)
                    .OrderBy(n => n.DocId)
                    .Skip(pageIndex * pageSize)
                    .Take(pageSize)
                    .Select(n => new DocumentModel
                    {
                        DocumentID = n.DocId,
                        ObjectID = n.ObjectId,
                        ObjectType = n.ObjectType,
                        DocumentType = n.DocType,
                        DocumnetNameOnDisk = n.DocNameOnDisk,
                        DocumentOriginalName = n.DocOriginalName,
                        AddedOn = n.Addedon.ToString(),
                    })
                    .ToList();
            }
            return documents;
        }

        public static int GetTotalDocuments(int objectId)
        {
            int totalDoc = 0;

            try
            {
                using (var context = new DemoUserManagementEntities())
                {
                    totalDoc = context.Documents.Count(n => n.ObjectId == objectId); ;
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }

            return totalDoc;
        }

        public static int IsUser(string email, string password)
        {
            int userId = 0;
            try
            {
                using (var context = new DemoUserManagementEntities())
                {
                    if ((email != "") && password != "")
                    {
                        var user = context.UserDetails.Single(x => x.Email == email);
                        //var userroles = context.UserRoles.Where(x => x.UserId == user.UserId).ToList();
                        if (user.Password == password)
                        {
                            userId = user.UserId;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
            return userId;
        }

        public static bool IsAdmin(int userId)
        {
            using (var context = new DemoUserManagementEntities())
            {
                var isAdmin = (from ur in context.UserRoles
                               join r in context.Roles on ur.RoleID equals r.RoleId
                               where ur.UserId == userId && r.IsAdmin == "True"
                               select r).Any();

                return isAdmin;
            }
        }

        public static bool EmailExists(string email)
        {

            using (var context = new DemoUserManagementEntities())
            {
                return context.UserDetails.Any(u => u.Email == email);
            }
        }

        public static bool UserEmail(string userId, string email)
        {
            bool emailExists=false;
            using (var context = new DemoUserManagementEntities())
            {
                if (int.TryParse(userId, out int userIdInt))
                {
                    emailExists = context.UserDetails.Any(u => u.UserId == userIdInt && u.Email == email);
                }
            }
            return emailExists;
        }

    }
}

