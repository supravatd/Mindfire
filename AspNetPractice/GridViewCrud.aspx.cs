using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspNetPractice
{
    public partial class GridViewCrud : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int customerId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            GridViewRow row = GridView1.Rows[e.RowIndex];
            string country = (row.FindControl("txtCountry") as TextBox).Text;

            string constr = ConfigurationManager.ConnectionStrings["customer"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "UPDATE Customers SET Country = @Country WHERE CustomerId = @CustomerId";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Country", country);
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            GridView1.EditIndex = -1;
            BindGrid();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindGrid();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int customerId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);

            string constr = ConfigurationManager.ConnectionStrings["customer"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "DELETE FROM Customers WHERE CustomerId = @CustomerId";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            BindGrid();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Insert")
            {
                GridViewRow row = GridView1.FooterRow;
                string newContactName = (row.FindControl("txtNewContactName") as TextBox).Text;

                string constr = ConfigurationManager.ConnectionStrings["customer"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    string query = "INSERT INTO Customers (ContactName) VALUES (@ContactName)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@ContactName", newContactName);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                BindGrid();
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        private void BindGrid()
        {
            DataTable dt = GetData();
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        private DataTable GetData()
        {
            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["customer"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "SELECT CustomerId, ContactName, City, Country FROM Customers";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {

        }
    }
}
