using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QueryStringExample
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void btnSubmit_Click(object sender, EventArgs e)
        {
            //Response.Redirect("Display.aspx?name="+txtName.Text+"&age="+txtAge.Text+"&rollno="+txtRollNo.Text);
            Response.Redirect("Display.aspx?name=" + Server.UrlEncode(txtName.Text) + "&age=" + Server.UrlEncode(txtAge.Text) + "&rollno=" + Server.UrlEncode(txtRollNo.Text));

        }
    }
}