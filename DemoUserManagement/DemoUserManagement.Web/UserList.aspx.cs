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
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
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
            string id = DisplayUser.SelectedRow.Cells[0].Text;
            Response.Redirect($"UserForm.aspx?UserId={id}");
        }
        protected void NewUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserForm.aspx");
        }
    }
}