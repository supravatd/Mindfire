using StudentLayers.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using static DemoUserManagement.Models.Model;

namespace DemoUserManagement.Controllers
{
    public class DocumentController : Controller
    {
        // GET: Document
        public ActionResult _DocumentPartial(int objectId, int? page, string sortBy)
        {
            int pageSize = 3;
            int pageNumber = page ?? 1;

            ViewBag.DocPageSize = pageSize;
            ViewBag.DocObjectId = objectId;
            ViewBag.DocSortBy = sortBy;
            var prevSortOrder = Request.QueryString["sortOrder"];

            List<DocumentModel> documents = Business.Business.GetUploadedDocuments(objectId, pageNumber, pageSize, sortBy);

            ViewBag.DocSortOrder = prevSortOrder == "asc" ? "desc" : "asc";

            ViewBag.DocPageSize = pageSize;
            ViewBag.DocDocuments = documents;

            return PartialView("_DocumentPartial", ViewBag.DocDocuments);
        }


        [HttpPost]
        public ActionResult GetDocumentTypes()
        {
            var documentTypes = Business.Business.GetDocumentType();

            var result = documentTypes.Select(dt => new
            {
                DocumentTypeID = dt.DocumentTypeID,
                DocumentTypeName = dt.DocumentTypeName
            });

            return Json(new { d = result }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UploadFile()
        {
            try
            {
                var file = Request.Files[0];
                if (file != null && file.ContentLength > 0)
                {
                    var documentTypeIdString = Request.Form["documentTypeId"];
                    int objectId = Convert.ToInt32(Request.Form["objectId"]);
                    int objectType = Convert.ToInt32(Request.Form["objectType"]);
                    string guid = Guid.NewGuid().ToString();
                    string fileExtension = Path.GetExtension(file.FileName);
                    string fileNameOnDisk = guid + fileExtension;
                    string fileNameOriginal = Path.GetFileName(file.FileName);
                    string pathToSave = Server.MapPath("~/UploadDocuments/" + fileNameOnDisk);
                    file.SaveAs(pathToSave);

                    var document = new DocumentModel
                    {
                        ObjectID = objectId,
                        ObjectType = objectType,
                        DocumentType = Convert.ToInt32(documentTypeIdString),
                        DocumentOriginalName = fileNameOriginal,
                        DocumnetNameOnDisk = fileNameOnDisk,
                        AddedOn = DateTime.Now.ToString("d")
                    };

                    Business.Business.AddDocument(document);

                    var fileInfo = new
                    {
                        FileName = fileNameOnDisk,
                        FileSize = file.ContentLength
                    };

                    return Json(fileInfo);
                }
                return Json("Error: No file uploaded.");
            }
            catch (Exception ex)
            {
                return Json("Error: " + ex.Message);
            }
        }

        [HttpGet]
        public ActionResult DownloadFile(string fileName, string originalFileName)
        {
            string filePath = Server.MapPath("~/UploadDocuments/" + fileName);
            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, "application/octet-stream", originalFileName);
        }
    }
}