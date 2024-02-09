using Microsoft.AspNet.Identity;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace AspNetPractice
{
    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblPageName.Text = PageName;
            UserId.Text=Context.User.Identity.GetUserName();
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        protected void GridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["dt"];
            if (dt != null)
            {
                dt.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
                GridView1.DataSource = dt;
                GridView1.DataBind();
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


        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGrid(e.NewPageIndex + 1, GridView1.PageSize);
        }

        protected void PageNumber_Changed(object sender, EventArgs e)
        {
            int pageNumber = int.Parse(ddlPageNumber.SelectedValue);
            BindGrid(pageNumber, GridView1.PageSize);
        }

        public string PageName { get; set; }
        public string UserID { get; set; }

        protected void Add_Click(object sender, EventArgs e)
        {
            string note = Note.Text;
            string userId = Context.User.Identity.GetUserName();

            string connectionString = ConfigurationManager.ConnectionStrings["Notes"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string commandText = "INSERT INTO Notes (NoteData, UserID, PageName, DateTimeAdded) VALUES (@Note, @UserId, @PageName, @DateTime)";

                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                    command.Parameters.AddWithValue("@Note", note);
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.Parameters.AddWithValue("@PageName", PageName);
                    command.Parameters.AddWithValue("@DateTime", DateTime.Now);

                    command.ExecuteNonQuery();
                }
            }

            BindGrid();
        }

        private void BindGrid(int pageIndex = 1, int pageSize = 10)
        {
            if (string.IsNullOrEmpty(PageName))
            {
                return;
            }

            string connectionString = ConfigurationManager.ConnectionStrings["Notes"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                int startRowIndex = (pageIndex - 1) * pageSize + 1;
                int endRowIndex = pageIndex * pageSize;

                string query = $@"SELECT * FROM (
                    SELECT ROW_NUMBER() OVER (ORDER BY NoteID) AS NoteID, NoteData, UserID, PageName, DateTimeAdded 
                    FROM Notes
                 ) AS NotesPage
                 WHERE NoteID BETWEEN @StartRowIndex AND @EndRowIndex";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StartRowIndex", startRowIndex);
                    command.Parameters.AddWithValue("@EndRowIndex", endRowIndex);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    if (dataTable.Rows.Count > 0)
                    {
                        GridView1.DataSource = dataTable;
                        GridView1.DataBind();
                    }
                    else
                    {
                        Console.WriteLine("No Data");
                    }
                }
            }
        }


    }
}
