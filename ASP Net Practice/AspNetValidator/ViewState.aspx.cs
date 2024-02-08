using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspNetValidator
{
    public partial class ViewState : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void btnSubmit_Click(object sender, EventArgs e)
        {
            //ViewState["user"] = txtUsername.Text;
            Session["user"] = txtUsername.Text;
            //ViewState["password"] = txtPassword.Text;

            txtUsername.Text = "";
            txtPassword.Text = "";
            Response.Redirect("SessionStatePractice.aspx");
        }
        public void btnRestore_Click(object sender, EventArgs e)
        {
            txtUsername.Text = ViewState["user"].ToString();
            txtPassword.Text = ViewState["password"].ToString();
        }
    }
}