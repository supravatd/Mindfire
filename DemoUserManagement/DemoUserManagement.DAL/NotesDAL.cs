using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoUserManagement.DAL
{
    public class NotesDAL
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["users"].ConnectionString;

        public void AddNote(string note, string userId, string pageName, DateTime dateTime)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string commandText = "INSERT INTO Notes (NoteData, UserID, PageName, DateTimeAdded) VALUES (@Note, @UserId, @PageName, @DateTime)";

                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                    command.Parameters.AddWithValue("@Note", note);
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.Parameters.AddWithValue("@PageName", pageName);
                    command.Parameters.AddWithValue("@DateTime", dateTime);

                    command.ExecuteNonQuery();
                }
            }
        }

        public DataTable GetNotes(int pageIndex, int pageSize)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                int startRowIndex = (pageIndex - 1) * pageSize + 1;
                int endRowIndex = pageIndex * pageSize;

                string query = $@"SELECT * FROM (
                SELECT ROW_NUMBER() OVER (ORDER BY NoteID) AS NoteID, NoteData, UserID, PageName, DateTimeAdded 
                FROM Notes) AS NotesPage WHERE NoteID BETWEEN @StartRowIndex AND @EndRowIndex";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StartRowIndex", startRowIndex);
                    command.Parameters.AddWithValue("@EndRowIndex", endRowIndex);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                }
            }

            return dataTable;
        }
    }
}

