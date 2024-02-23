using DemoUserManagement.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Web.UI.WebControls;

namespace DemoUserManagement.Web
{
    public partial class UserList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }
        private void BindGridView()
        {
            int pageIndex = DisplayUser.PageIndex;
            int pageSize = DisplayUser.PageSize;
            string sortExpression = ViewState["SortExpression"] as string ?? "UserId";
            string sortDirection = ViewState["SortDirection"] as string ?? "ASC";

            int totalRecords = Business.Business.GetTotalUsers();
            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            DisplayUser.VirtualItemCount = totalRecords;
            List<UserModel> userList = Business.Business.GetAllUsers(pageIndex, pageSize);

            if (!string.IsNullOrEmpty(sortExpression))
            {
                if (sortDirection == "ASC")
                {
                    userList = userList.OrderBy(u => GetPropertyValue(u, sortExpression)).ToList();
                }
                else
                {
                    userList = userList.OrderByDescending(u => GetPropertyValue(u, sortExpression)).ToList();
                }
            }

            DisplayUser.DataSource = userList;
            DisplayUser.DataBind();
            DisplayUser.PagerSettings.PageButtonCount = totalPages;
        }

        protected void DisplayUser_Edit(object sender, GridViewEditEventArgs e)
        {
            string userId = DisplayUser.DataKeys[e.NewEditIndex].Values["UserId"].ToString();
            Response.Redirect("UserForm.aspx?UserId=" + userId);
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
            ViewState["SortExpression"] = e.SortExpression;
            ViewState["SortDirection"] = GetSortDirection();

            BindGridView();
        }


        private object GetPropertyValue(UserModel user, string propertyName)
        {
            Type userType = typeof(UserModel);
            PropertyInfo property = userType.GetProperty(propertyName);

            if (property != null)
            {
                return property.GetValue(user, null);
            }
            else
            {
                return null;
            }
        }

        private string GetSortDirection()
        {
            // Toggle sorting direction between ASC and DESC
            if (ViewState["SortDirection"] == null || ViewState["SortDirection"].ToString() == "ASC")
            {
                return "DESC";
            }
            else
            {
                return "ASC";
            }
        }

        protected string GenerateDownloadLink(object fileGuid, object fileOriginal)
        {
            if (fileGuid == null || fileOriginal == null)
            {
                return string.Empty;
            }

            string fileGuidStr = fileGuid.ToString();
            string fileOriginalStr = fileOriginal.ToString();
            string fileExtension = Path.GetExtension(fileOriginalStr);
            string downloadLink = string.Format("{0}/{1}{2}", ResolveUrl("~/Uploads/"), fileGuidStr, fileExtension);
            string encodedFileName = Server.UrlEncode(fileOriginalStr);
            return string.Format("<a href='{0}' download='{1}'>{2}</a>", downloadLink, encodedFileName, fileOriginalStr);
        }

    }
}