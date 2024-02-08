using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspNetValidator
{
    public partial class SessionStatePractice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"].ToString() != "")
            {
                Response.Write("Welcome "+Session["user"]);
            }
            else
            {
                Response.Redirect("ViewState.aspx");
            }
        }
    }
}