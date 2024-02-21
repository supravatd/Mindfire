using StudentLayers.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using static DemoUserManagement.Models.Model;
using static DemoUserManagement.Utils.Utils;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace DemoUserManagement.Web
{
    /// <summary>
    /// Summary description for FileUploadHandler
    /// </summary>
    public class FileUploadHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        public Utils.Utils.ObjectType ObjectTypeName { get; set; }
        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.Files.Count > 0)
            {
                HttpPostedFile file = context.Request.Files[0];

                if (file.ContentLength > 0)
                {
                    try
                    {
                        string documentTypeIdString = context.Request.Form["documentTypeId"];
                        string guid = Guid.NewGuid().ToString();
                        string fileExtension = Path.GetExtension(file.FileName);
                        string fileNameOnDisk = guid + fileExtension;
                        string fileNameOriginal = Path.GetFileName(file.FileName);
                        string pathToSave = HttpContext.Current.Server.MapPath("~/UploadDocuments/" + fileNameOnDisk);
                        file.SaveAs(pathToSave);

                        var fileInfo = new
                        {
                            FileName = fileNameOnDisk,
                            FileSize = file.ContentLength
                        };

                        string fileInfoJson = new JavaScriptSerializer().Serialize(fileInfo);
                        context.Response.Write(fileInfoJson);
                        if (int.TryParse(documentTypeIdString, out int documentTypeId))
                        {
                            AddDocumentToDatabase(fileNameOriginal, documentTypeId, fileNameOnDisk);
                        }

                    }
                    catch (Exception ex)
                    {
                        context.Response.Write("Error: " + ex.Message);
                    }
                }
                else
                {
                    context.Response.Write("Error: Empty file.");
                }
            }
            else
            {
                context.Response.Write("Error: No file uploaded.");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        protected void AddDocumentToDatabase(string fileName, int documentTypeId, string guid)
        {
            try
            {
                SessionModel session = SessionManager.GetSessionModel();

                var document = new DocumentModel
                {
                    ObjectID = session.UserId,
                    ObjectType = (int)ObjectType.UserForm,
                    DocumentType = documentTypeId,
                    DocumentOriginalName = fileName,
                    DocumnetNameOnDisk = guid,
                    AddedOn = DateTime.Now.ToString("d")
                };

                Business.Business.AddDocument(document);
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
        }
    }
}