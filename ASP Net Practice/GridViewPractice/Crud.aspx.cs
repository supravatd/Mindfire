using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GridViewPractice
{
    public partial class Crud : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void BindMyGridview()
        {
            if (Session["myDatatable"] != null)
            {
                DataTable dt = (DataTable)Session["myDatatable"];
                if ((dt != null) && (dt.Rows.Count > 0))
                {
                    GridView1.Visible = true;
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.Visible = false;
                }
            }
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            TextBox TextBoxWithID = (TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox2");
            TextBox TextBoxWithName = (TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox4");
            string NewID = TextBoxWithID.Text.ToString();
            string NewName = TextBoxWithName.Text.ToString();
            DataTable dt = (DataTable)Session["myDatatable"];
            DataRow dr = dt.Rows[e.RowIndex];
            dr["ID"] = NewID;
            dr["Name"] = NewName;
            dr.AcceptChanges();
            Session["myDatatable"] = dt;
            GridView1.EditIndex = -1;
            BindMyGridview();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = (DataTable)Session["myDatatable"];
            DataRow dr = dt.Rows[e.RowIndex];
            dt.Rows.Remove(dr);
            GridView1.EditIndex = -1;
            BindMyGridview();
        }
    }
}