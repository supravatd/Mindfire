using DemoUserManagement.Models;
using DemoUserManagement.Web.User_Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoUserManagement.Web
{
    public partial class UserList : System.Web.UI.Page
    {
        string id = "";
        protected bool IsEditMode
        {
            get { return ViewState["IsEditMode"] != null && (bool)ViewState["IsEditMode"]; }
            set { ViewState["IsEditMode"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IsEditMode = !string.IsNullOrEmpty(Request.QueryString["UserId"]);
                BindGridView();
            }
        }
        private void BindGridView()
        {
            Business.Business user=new Business.Business();
            DisplayUser.DataSource = user.GetAllUsers();
            DisplayUser.DataBind();
        }
        protected void DisplayUser_Edit(object sender, EventArgs e)
        {
            id = DisplayUser.SelectedRow.Cells[0].Text;
            LoadUserDetails(id);
        }
        private void LoadUserDetails(string userId)
        {
            Business.Business userBLL = new Business.Business();
            UserModel user = userBLL.GetUserById(id);

            Session["UserDetails"] = user;
            Response.Redirect($"UserForm.aspx?UserId={id}");
        }
        protected void NewUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserForm.aspx");
        }
    }
}