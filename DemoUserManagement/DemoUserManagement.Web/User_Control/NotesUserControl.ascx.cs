using DemoUserManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace DemoUserManagement.Web.User_Control
{
    public partial class NotesUserControl : System.Web.UI.UserControl
    {
        public string userId { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindNotesGrid();
            }
        }
        public string PageName { get; set; }
        protected void bttnAddNotes_Click(object sender, EventArgs e)
        {
            userId = Request.QueryString["UserId"];

            if (!string.IsNullOrEmpty(userId) && int.TryParse(userId, out int userIdValue))
            {
                NoteModel note = new NoteModel
                {
                    UserId = userIdValue,
                    NoteData = txtNotes.Text,
                    PageName = PageName.ToString(),
                    DateTimeAdded = DateTime.Now.ToString("d"),
                };

                Business.Business noteBLL = new Business.Business();
                noteBLL.AddNote(note);

                txtNotes.Text = "";

                BindNotesGrid();
            }
        }

        private void BindNotesGrid()
        {
            Business.Business noteBLL = new Business.Business();
            NotesGrid.DataSource = noteBLL.GetAllNotes();
            NotesGrid.DataBind();
        
        }
    }
}