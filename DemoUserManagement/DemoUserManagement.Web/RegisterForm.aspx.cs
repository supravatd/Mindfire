using DemoUserManagement.Models;
using StudentLayers.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using static DemoUserManagement.Models.Model;

namespace DemoUserManagement.Web
{
    public partial class RegisterForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["UserId"]))
                {
                    if (int.TryParse(Request.QueryString["UserId"], out int userId))
                    {
                        UserModel user = Business.Business.GetUserById(userId);
                        string userJson = Newtonsoft.Json.JsonConvert.SerializeObject(user);

                        string script = $"<script>populateFormFields({userJson});</script>";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "populateFormScript", script);

                        NotesUserControl.ObjectId = userId;
                        DocumentUserControl.ObjectId = userId;

                        if (CheckUserRole(userId) == "user")
                        {
                            RedirectIfUnauthorized(userId);
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

        private string CheckUserRole(int userId)
        {
            bool isAdmin = Business.Business.IsAdmin(userId);
            return isAdmin ? "admin" : "user";
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

        [WebMethod]
        public static void SubmitFormData(UserModel user, AddressModel presentAddress, AddressModel permanentAddress)
        {
            try
            {
                Business.Business.AddUserAddress(user, presentAddress, permanentAddress);

                int userId = Business.Business.GetUserId(user);
                HttpContext.Current.Response.Redirect("RegisterForm.aspx?UserId=" + userId, false);
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
            return new JavaScriptSerializer().Serialize(stateList);
        }

        [WebMethod]
        public static void BindDropDownList<T>(string ddlId, List<T> list, string textField, string valueField)
        {
            var page = HttpContext.Current.CurrentHandler as Page;
            var ddl = page.FindControl(ddlId) as DropDownList;

            ddl.DataSource = list;
            ddl.DataTextField = textField;
            ddl.DataValueField = valueField;
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select", ""));
        }

        [WebMethod]
        public static void LoadUserDetails()
        {

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
        private string GetCountryNameById(int countryId)
        {
            List<CountryModel> countryList = Business.Business.GetCountryList();
            CountryModel country = countryList.FirstOrDefault(c => c.CountryId == countryId);
            return country != null ? country.CountryName : null;
        }
        [WebMethod]
        public string GetStateNameById(int stateId, int countryId)
        {
            List<StateModel> states = Business.Business.GetStateList(countryId);
            StateModel state = states.FirstOrDefault(s => s.StateId == stateId);
            return state != null ? state.StateName : null;
        }
    }
}