using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.DynamicData;
using System.Drawing.Printing;

namespace AspNetPractice
{
    public partial class PagingPractice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid(1, 10);
                PopulatePageDropdown();
            }
            else
            {
                BindGrid(GridView1.PageIndex + 1, GridView1.PageSize);
            }
        }

        private void BindGrid(int pageIndex, int pageSize)
        {
            string constr = ConfigurationManager.ConnectionStrings["customer"].ConnectionString;
            string query = "SELECT CustomerId, ContactName, City, Country FROM (SELECT CustomerId, ContactName, City, Country, ROW_NUMBER() OVER (ORDER BY CustomerId) " +
                "AS RowNum FROM Customers) AS TempTable WHERE RowNum BETWEEN @Offset AND @Offset + @PageSize - 1";
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Offset", (pageIndex - 1) * pageSize + 1);
                    cmd.Parameters.AddWithValue("@PageSize", pageSize);

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }
            }
        }

        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGrid(e.NewPageIndex + 1, GridView1.PageSize);
        }

        private void PopulatePageDropdown()
        {
            int totalRecords;

            string constr = ConfigurationManager.ConnectionStrings["customer"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Customers", con))
                {
                    con.Open();
                    totalRecords = (int)cmd.ExecuteScalar();
                }
            }

            int totalPages = (int)Math.Ceiling((double)totalRecords / GridView1.PageSize);

            for (int i = 1; i <= totalPages; i++)
            {
                ddlPageNumber.Items.Add(i.ToString());
            }
        }

        protected void PageNumber_Changed(object sender, EventArgs e)
        {
            int pageNumber = int.Parse(ddlPageNumber.SelectedValue);
            BindGrid(pageNumber, GridView1.PageSize);
        }

        protected void GoButton_Clicked(object sender, EventArgs e)
        {
            int pageNumber = int.Parse(ddlPageNumber.SelectedValue);
            BindGrid(pageNumber, GridView1.PageSize);
        }

        protected void GridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dt = GetData();
            if (dt != null)
            {
                dt.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        private DataTable GetData()
        {
            string constr = ConfigurationManager.ConnectionStrings["customer"].ConnectionString;
            string query = "SELECT CustomerId, ContactName, City, Country FROM (SELECT CustomerId, ContactName, City, Country, ROW_NUMBER() OVER (ORDER BY CustomerId) " +
                "AS RowNum FROM Customers) AS TempTable WHERE RowNum BETWEEN @Offset AND @Offset + @PageSize - 1";
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Offset", (GridView1.PageIndex) * GridView1.PageSize + 1);
                    cmd.Parameters.AddWithValue("@PageSize", GridView1.PageSize);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        private string GetSortDirection(string column)
        {
            string sortDirection = "ASC";
            string sortExpression = ViewState["SortExpression"] as string;

            if (sortExpression != null)
            {
                if (sortExpression == column)
                {
                    string lastDirection = ViewState["SortDirection"] as string;
                    if ((lastDirection != null) && (lastDirection == "ASC"))
                    {
                        sortDirection = "DESC";
                    }
                }
            }

            ViewState["SortExpression"] = column;
            ViewState["SortDirection"] = sortDirection;

            return sortDirection;
        }


    }
}