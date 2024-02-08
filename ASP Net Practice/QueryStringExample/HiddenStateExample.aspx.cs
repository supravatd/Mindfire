using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QueryStringExample
{
    public partial class HiddenStateExample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HiddenField1.Value = DateTime.Now.ToString("D");
            lblCurrentDateTime.Text = Convert.ToString(HiddenField1.Value);
        }
    }
}