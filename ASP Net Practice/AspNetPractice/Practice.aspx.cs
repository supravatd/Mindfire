using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspNetPractice
{
    public partial class Practice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cookies["computer"].Expires = DateTime.Now.AddDays(-1);
        }
        protected void login_Click(object sender, EventArgs e)
        {
            if (password.Text == "qwe123")
            { 
                Session["email"] = email.Text;
            }  
            if (Session["email"] != null)
            {
                ConfirmPassword.Text = "This email is stored to the session.";
                Gender.Text = Session["email"].ToString();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            genderId.Text = "";
            if (Male.Checked)
            {
                genderId.Text = "Your gender is " + Male.Text;
            }
            else genderId.Text = "Your gender is " + Female.Text;

            var message = "";
            if (CheckBox1.Checked)
            {
                message = CheckBox1.Text + " ";
            }
            if (CheckBox2.Checked)
            {
                message += CheckBox2.Text + " ";
            }
            if (CheckBox3.Checked)
            {
                message += CheckBox3.Text;
            }
            //ShowCourses.Text = message;


            if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
            {
                var count = 0;
                foreach (HttpPostedFile uploadedFile in FileUpload1.PostedFiles)
                {
                    string fn = System.IO.Path.GetFileName(uploadedFile.FileName);
                    string SaveLocation = Server.MapPath("upload") + "\\" + fn;
                    try
                    {
                        uploadedFile.SaveAs(SaveLocation);
                        count++;
                    }
                    catch (Exception ex)
                    {
                        FileUploadStatus.Text = "Error: " + ex.Message;
                    }
                }
                if (count > 0)
                {
                    FileUploadStatus.Text = count + " files has been uploaded.";
                }
            }
            else
            {
                FileUploadStatus.Text = "Please select a file to upload.";
            }


            Password.Text = "";
            if (CheckBox1.Checked)
                Response.Cookies["computer"]["Cricket"] = "Cricket";
            if (CheckBox2.Checked)
                Response.Cookies["computer"]["Football"] = "Football";
            if (CheckBox3.Checked)
                Response.Cookies["computer"]["Volleyball"] = "Volleball";

            if (Request.Cookies["computer"].Values.ToString() != null)
            {
                if (Request.Cookies["computer"]["Cricket"] != null)
                    ShowCourses.Text += Request.Cookies["computer"]["Cricket"] + " ";
                if (Request.Cookies["computer"]["Football"] != null)
                    ShowCourses.Text += Request.Cookies["computer"]["Football"] + " ";
                if (Request.Cookies["computer"]["Volleyball"] != null)
                    ShowCourses.Text += Request.Cookies["computer"]["Volleyball"] + " ";
            }
            else ShowCourses.Text = "Please select your choice";
            Response.Cookies["computer"].Expires = DateTime.Now.AddDays(-1);
        }
        public void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            ShowDate.Text = "You Selected: " + Calendar1.SelectedDate.ToString("d");
        }
        public void LinkButton1_Click(object sender, EventArgs e)
        {
            LinkButton.Text = "Welcome to Asp.Net";
        }

        protected void Unnamed1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}