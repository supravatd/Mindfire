using DemoUserManagement.Models;
using DemoUserManagement.Utils;
using StudentLayers.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.UI.WebControls;
using static DemoUserManagement.Utils.Utils;

namespace DemoUserManagement.Web.User_Control
{
    public partial class NotesUserControl : System.Web.UI.UserControl
    {
        public int ObjectId { get; set; }
        public Utils.Utils.ObjectType ObjectTypeName { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["ObjectId"] = ObjectId;
                BindNotesGrid();
            }
        }

        protected void bttnAddNotes_Click(object sender, EventArgs e)
        {
            try
            {
                int userIdValue;
                if (!string.IsNullOrEmpty(ViewState["ObjectId"].ToString()) && int.TryParse(ViewState["ObjectId"].ToString(), out userIdValue))
                {
                    NoteModel note = new NoteModel
                    {
                        ObjectId = userIdValue,
                        NoteData = txtNotes.Text,
                        ObjectType = (int)ObjectType.UserForm,
                        DateTimeAdded = DateTime.Now.ToString("d"),
                    };

                    Business.Business noteBLL = new Business.Business();
                    noteBLL.AddNote(note);

                    txtNotes.Text = "";

                    BindNotesGrid();
                } 
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
        }

        protected void NotesGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                NotesGrid.PageIndex = e.NewPageIndex;
                BindNotesGrid();
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
        }  

        protected void NotesGrid_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                string sortExpression = e.SortExpression;
                string sortDirection = GetSortDirection();
                ViewState["SortExpression"] = sortExpression;
                ViewState["SortDirection"] = sortDirection;

                BindNotesGrid();
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
        }

        private void BindNotesGrid()
        {
            try
            {
                int pageIndex = NotesGrid.PageIndex;
                int pageSize = NotesGrid.PageSize;
                string sortExpression = ViewState["SortExpression"] as string ?? "NoteId";
                string sortDirection = ViewState["SortDirection"] as string ?? "ASC";

                Business.Business noteBLL = new Business.Business();
                int totalNotes = noteBLL.GetTotalNotes(Convert.ToInt32(ViewState["ObjectId"]));
                int totalPages = (int)Math.Ceiling((double)totalNotes / pageSize);

                NotesGrid.VirtualItemCount = totalNotes;
                List<NoteModel> notes = noteBLL.GetAllNotes(pageIndex, pageSize, Convert.ToInt32(ViewState["ObjectId"]));

                // Apply sorting
                if (!string.IsNullOrEmpty(sortExpression))
                {
                    if (sortDirection == "ASC")
                    {
                        notes = notes.OrderBy(n => GetPropertyValue(n, sortExpression)).ToList();
                    }
                    else
                    {
                        notes = notes.OrderByDescending(n => GetPropertyValue(n, sortExpression)).ToList();
                    }
                }

                NotesGrid.DataSource = notes;
                NotesGrid.DataBind();
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
        }

        private string GetSortDirection()
        {
            if (ViewState["SortDirection"] == null)
            {
                ViewState["SortDirection"] = "ASC";
            }
            else
            {
                if (ViewState["SortDirection"].ToString() == "ASC")
                {
                    ViewState["SortDirection"] = "DESC";
                }
                else
                {
                    ViewState["SortDirection"] = "ASC";
                }
            }

            return ViewState["SortDirection"].ToString();
        }

        private object GetPropertyValue(object obj, string propertyName)
        {
            Type objType = obj.GetType();
            PropertyInfo propInfo = objType.GetProperty(propertyName);

            if (propInfo != null)
            {
                return propInfo.GetValue(obj);
            }
            else
            {
                return null;
            }
        }

        public int GetTotalNotes(int objectId)
        {
            Business.Business noteBLL = new Business.Business();
            return noteBLL.GetTotalNotes(objectId);
        }
    }
}
