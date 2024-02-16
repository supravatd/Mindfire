using StudentLayers.Utils;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static DemoUserManagement.Models.Model;
using static DemoUserManagement.Utils.Utils;

namespace DemoUserManagement.Web.User_Control
{
    public partial class DocumentUserControl : System.Web.UI.UserControl
    {
        public int ObjectId { get; set; }
        public Utils.Utils.ObjectType ObjectTypeName { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlDocumentType.DataSource = Business.Business.GetDocumentType();
                ddlDocumentType.DataBind();
                ViewState["ObjectId"] = ObjectId;
                BindGridView();
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (fileUpload.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(fileUpload.FileName);
                    string fileExtension = Path.GetExtension(filename);
                    string guid = Guid.NewGuid().ToString();
                    string folderPath = Server.MapPath("~/UploadDocuments/");
                    string filePath = Path.Combine(folderPath, guid + fileExtension);

                    fileUpload.SaveAs(filePath);

                    // Get the selected document type ID from the dropdown list
                    int documentTypeId = int.Parse(ddlDocumentType.SelectedValue);

                    DocumentModel document = new DocumentModel
                    {
                        ObjectID = Convert.ToInt32(ViewState["ObjectId"]),
                        ObjectType = (int)ObjectType.UserForm,
                        DocumentType = documentTypeId,
                        DocumentOriginalName = filename,
                        DocumnetNameOnDisk = guid + fileExtension,
                        AddedOn = DateTime.Now.ToString("d")
                    };

                    Business.Business.AddDocument(document);
                    BindGridView();
                }
                catch (Exception ex)
                {
                    Logger.AddData(ex);
                }
            }
        }

        protected void DocumentGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                DocumentGrid.PageIndex = e.NewPageIndex;
                BindGridView();
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
        }

        protected void DocumentGrid_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                string sortExpression = e.SortExpression;
                string sortDirection = GetSortDirection();
                ViewState["SortExpression"] = sortExpression;
                ViewState["SortDirection"] = sortDirection;

                BindGridView();
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
        }

        private void BindGridView()
        {
            try
            {
                int pageIndex = DocumentGrid.PageIndex;
                int pageSize = DocumentGrid.PageSize;
                string sortExpression = ViewState["SortExpression"] as string ?? "DocumentId";
                string sortDirection = ViewState["SortDirection"] as string ?? "ASC";

                int totalDocuments = Business.Business.GetTotalDocuments(Convert.ToInt32(ViewState["ObjectId"]));
                int totalPages = (int)Math.Ceiling((double)totalDocuments / pageSize);

                DocumentGrid.VirtualItemCount = totalDocuments;
                List<DocumentModel> documents = Business.Business.GetUploadedDocuments(pageIndex, pageSize, Convert.ToInt32(ViewState["ObjectId"]));

                if (!string.IsNullOrEmpty(sortExpression))
                {
                    if (sortDirection == "ASC")
                    {
                        documents = documents.OrderBy(d => GetPropertyValue(d, sortExpression)).ToList();
                    }
                    else
                    {
                        documents = documents.OrderByDescending(d => GetPropertyValue(d, sortExpression)).ToList();
                    }
                }

                DocumentGrid.DataSource = documents;
                DocumentGrid.DataBind();
                DocumentGrid.PagerSettings.PageButtonCount = totalPages;
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

    }
}