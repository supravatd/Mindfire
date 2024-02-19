using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoUserManagement.Web
{
    public partial class CheckUserExists : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string email = Request.QueryString["email"];

            if (!string.IsNullOrEmpty(email))
            {
                bool userExists = Business.Business.UserExists(email);
                Response.Write(userExists.ToString());
                Response.End();
            }
        }
    }
}