using DemoUserManagement.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;

namespace DemoUserManagement.Web
{
    public partial class UserList : System.Web.UI.Page
    {
        string id = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }
        private void BindGridView()
        {
            Business.Business userBLL = new Business.Business();
            List<UserModel> userList = userBLL.GetAllUsers();

            DisplayUser.DataSource = userList;
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
            UserModel user = userBLL.GetUserById(userId);

            Session["UserDetails"] = user;
            Response.Redirect($"UserForm.aspx?UserId={userId}");
        }
        protected void NewUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserForm.aspx");
        }
        protected void DisplayUser_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DisplayUser.PageIndex = e.NewPageIndex;
            BindGridView();
        }

        protected void DisplayUser_Sorting(object sender, GridViewSortEventArgs e)
        {
            List<UserModel> userList = (List<UserModel>)DisplayUser.DataSource;

            if (userList != null)
            {
                if (e.SortDirection == SortDirection.Ascending)
                {
                    userList = userList.OrderBy(u => u.GetType().GetProperty(e.SortExpression).GetValue(u, null)).ToList();
                }
                else
                {
                    userList = userList.OrderByDescending(u => u.GetType().GetProperty(e.SortExpression).GetValue(u, null)).ToList();
                }

                DisplayUser.DataSource = userList;
                DisplayUser.DataBind();
            }
        }

        private string GetSortDirection()
        {
            if (ViewState["SortDirection"] == null)
            {
                ViewState["SortDirection"] = "ASC";
            }
            else
            {
                if (ViewState["SortDirection"].ToString() == "ASC")
                {
                    ViewState["SortDirection"] = "DESC";
                }
                else
                {
                    ViewState["SortDirection"] = "ASC";
                }
            }

            return ViewState["SortDirection"].ToString();
        }

        protected void DisplayUser_Paging(object sender, GridViewPageEventArgs e)
        {
            DisplayUser.PageIndex = e.NewPageIndex;
            BindGridView();
        }
    }
}
