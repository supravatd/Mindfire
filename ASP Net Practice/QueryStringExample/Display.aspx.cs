using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QueryStringExample
{
    public partial class Display : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Name.Text = Request.QueryString["name"];
            Age.Text = Request.QueryString["age"];
            RollNo.Text = Request.QueryString["rollno"];
        }
    }
}