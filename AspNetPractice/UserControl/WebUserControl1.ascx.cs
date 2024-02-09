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
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        public string PageName { get; set; }

        protected void Add_Click(object sender, EventArgs e)
        {
            string note = Note.Text;
            int userId;
            if (!int.TryParse(UserId.Text, out userId))
            {
                return;
            }

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

        private void BindGrid()
        {
            if (string.IsNullOrEmpty(PageName))
            {
                return;
            }

            string connectionString = ConfigurationManager.ConnectionStrings["Notes"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Notes";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
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
