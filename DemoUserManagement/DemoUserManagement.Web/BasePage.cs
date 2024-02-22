using DemoUserManagement.Web.User_Control;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Services;
using static DemoUserManagement.Models.Model;
using static DemoUserManagement.Utils.Utils;
using static System.Collections.Specialized.BitVector32;

namespace DemoUserManagement.Web
{
    public class BasePage : System.Web.UI.Page
    {
        public void Page_Init(object sender, EventArgs e)
        {

            SessionModel session = SessionManager.GetSessionModel();
            if (session != null && session.UserId != 0)
            {
                bool role = session.Role;
                if (IsLoginPage())
                {
                    if (role)
                    {
                        Response.Redirect("UserList.aspx");
                    }
                    else
                    {
                        Response.Redirect("RegisterForm.aspx?UserId=" + session.UserId);
                    }
                }
                else if (IsUserListPage())
                {
                    if (!role)
                    {
                        Response.Redirect("RegisterForm.aspx?UserId=" + session.UserId);
                    }
                }
                else if (IsRegisterForm())
                {
                    RedirectIfUnauthorized(session.UserId);
                }
            }
            string requestedUser = Request.QueryString["UserId"];

            if (!string.IsNullOrEmpty(requestedUser) && int.TryParse(requestedUser, out int requestedId) && session.UserId==0)
            {
                Response.Redirect("Login.aspx");
            }
            
        }

        private void RedirectIfUnauthorized(int userId)
        {
            string requestedUserId = Request.QueryString["UserId"];

            if (!string.IsNullOrEmpty(requestedUserId) && int.TryParse(requestedUserId, out int requestedId))
            {
                if (userId != requestedId)
                {
                    Response.Redirect("RegisterForm.aspx?UserId=" + userId);
                }
            }
        }

        private bool IsLoginPage()
        {
            if (HttpContext.Current.Request.Url.AbsoluteUri.ToLower().Contains("login.aspx"))
                return true;
            else
                return false;
        }

        private bool IsRegisterForm()
        {
            if (HttpContext.Current.Request.Url.AbsoluteUri.ToLower().Contains("registerform.aspx"))
                return true;
            else
                return false;
        }

        private bool IsUserListPage()
        {
            if (HttpContext.Current.Request.Url.AbsoluteUri.ToLower().Contains("userlist.aspx"))
                return true;
            else
                return false;
        }

        public bool IsSessionValid()
        {
            SessionModel session = SessionManager.GetSessionModel();
            return session.UserId.ToString() != null;
        }

        public bool IsUserFile(int objectId)
        {
            SessionModel session = SessionManager.GetSessionModel();
            if (!session.Role)
            {
                if (session.UserId != objectId)
                {
                    return false;
                }
            }
            return true;
        }

        [WebMethod]
        public static void AddNotes(string noteData, string objectId, string objectType)
        {
            NotesUserControl notes = new NotesUserControl();
            notes.AddNote(noteData, objectId, objectType);
        }

        [WebMethod]
        public static List<DocumentTypeModel> GetDocumentTypes()
        {
            return Business.Business.GetDocumentType();
        }

        [WebMethod]
        public static bool EmailExists(string email)
        {
            return Business.Business.EmailExists(email);
        }

        [WebMethod]
        public static bool CheckUserEmail(string userId, string email)
        {
            return Business.Business.CheckUserEmail(userId, email);
        }
    }
}