using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspNetPractice
{
    public partial class UserForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection("data source=.; database=Student; integrated security=SSPI"))
            {
                SqlDataAdapter sde = new SqlDataAdapter("Select * from student", con);
                DataSet ds = new DataSet();
                sde.Fill(ds);
                DataGrid1.DataSource = ds;
                DataGrid1.DataBind();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            message.Text = "Hello " + username.Text + " ! ";
            message.Text = message.Text + " <br/> You have successfuly Registered with the following details.";
            ShowUserName.Text = username.Text;
            ShowEmail.Text = EmailID.Text;
            if (Male.Checked)
            {
                ShowGender.Text = Male.Text;
            }
            else ShowGender.Text = Female.Text;
            var courses = "";
            if (CSharp.Checked)
            {
                courses = CSharp.Text + " ";
            }
            if (Sql.Checked)
            {
                courses += Sql.Text + " ";
            }
            if (AspNet.Checked)
            {
                courses += AspNet.Text;
            }
            ShowCourses.Text = courses;
            ShowUserNameLabel.Text = "User Name";
            ShowEmailIDLabel.Text = "Email ID";
            ShowGenderLabel.Text = "Gender";
            ShowCourseLabel.Text = "Courses";
            username.Text = "";
            EmailID.Text = "";
            Male.Checked = false;
            Female.Checked = false;
            CSharp.Checked = false;
            Sql.Checked = false;
            AspNet.Checked = false;

        }
    }
}