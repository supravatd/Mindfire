using DemoUserManagement.Models;
using DemoUserManagement.Web.User_Control;
using StudentLayers.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using static DemoUserManagement.Models.Model;
using static DemoUserManagement.Utils.Utils;

namespace DemoUserManagement.Web
{
    public partial class RegisterForm : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["UserId"]))
                {
                    if (int.TryParse(Request.QueryString["UserId"], out int userId))
                    {
                        SessionModel session = SessionManager.GetSessionModel();

                        if (session.Role == false)
                        {

                            NotesUserControl.ObjectId = session.UserId;
                            DocumentUserControl.ObjectId = session.UserId;
                            return;
                        }
                        else if (session.Role == true)
                        {
                            NotesUserControl.ObjectId = userId;
                            DocumentUserControl.ObjectId = userId;
                        }

                    }

                    NotesUserControl.Visible = true;
                    DocumentUserControl.Visible = true;
                }
                else
                {
                    NotesUserControl.Visible = false;
                    DocumentUserControl.Visible = false;
                }
            }
        }

        [WebMethod]
        public static void SubmitFormData(UserModel user, AddressModel presentAddress, AddressModel permanentAddress)
        {
            try
            {
                Business.Business.AddUserAddress(user, presentAddress, permanentAddress);
                HttpContext.Current.Response.Redirect("Login.aspx", false);
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
        }

        [WebMethod]
        public static string PopulateCountries()
        {
            List<CountryModel> countryList = Business.Business.GetCountryList();
            return new JavaScriptSerializer().Serialize(countryList);
        }

        [WebMethod]
        public static string PopulateStates(int countryId)
        {
            List<StateModel> stateList = Business.Business.GetStateList(countryId);
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(stateList);
        }

        [WebMethod]
        public static UserModel GetUserDetails(int userId)
        {
            try
            {
                return Business.Business.GetUserById(userId);
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
                throw;
            }
        }

        [WebMethod]
        public static void UpdateFormData(UserModel user)
        {
            try
            {
                BasePage basePage = new BasePage();
                if (basePage.IsSessionValid())
                {
                    SessionModel session = SessionManager.GetSessionModel();
                    int userId = session.UserId;
                    Business.Business.UpdateUser(userId, user);
                    HttpContext.Current.Response.Redirect("Login.aspx", false);
                }
                else
                {
                    HttpContext.Current.Response.Write("Session expired or invalid.");
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
        }
    }
}