using DemoUserManagement.Models;
using DemoUserManagement.Utils;
using Newtonsoft.Json;
using StudentLayers.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Services;
using System.Web.UI.WebControls;
using static DemoUserManagement.Models.Model;
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
                hfObjectId.Value = ObjectId.ToString();
                BindNotesGrid();
            }
        }

        public void AddNote(string noteData, string objectId)
        {
            try
            {
                NoteModel note = new NoteModel
                {
                    ObjectId = int.Parse(objectId),
                    NoteData = noteData,
                    ObjectType = (int)ObjectType.UserForm,
                    DateTimeAdded = DateTime.Now.ToString("d"),
                };

                Business.Business noteBLL = new Business.Business();
                noteBLL.AddNote(note);
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

        public void BindNotesGrid()
        {
            try
            {
                int pageIndex = NotesGrid.PageIndex;
                int pageSize = NotesGrid.PageSize;
                string sortExpression = ViewState["SortExpression"] as string ?? "NoteId";
                string sortDirection = ViewState["SortDirection"] as string ?? "ASC";

                int totalNotes = Business.Business.GetTotalNotes(Convert.ToInt32(ViewState["ObjectId"]));
                int totalPages = (int)Math.Ceiling((double)totalNotes / pageSize);

                NotesGrid.VirtualItemCount = totalNotes;
                List<NoteModel> notes = Business.Business.GetAllNotes(pageIndex, pageSize, Convert.ToInt32(ViewState["ObjectId"]));

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
            return Business.Business.GetTotalNotes(objectId);
        }
    }
}
