using StudentLayers.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoUserManagement.Web
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Login(object sender, EventArgs e)
        {
            try
            {
                string email = txtEmail.Text;
                string password = txtPassword.Text;
                int isUser = Business.Business.IsUser(email, password);

                if (isUser != -1)
                {
                    bool isadmin = Business.Business.IsAdmin(isUser);
                    Session["id"] = isUser;
                    if (isadmin == true)
                    {
                        Response.Redirect("UserForm.aspx?UserId=" + isUser, false);
                    }
                    else
                    {
                        Response.Redirect("UserList.aspx?UserId=" + isUser, false);
                    }

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Wrong Credentials');", true);
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
        }

    }
}