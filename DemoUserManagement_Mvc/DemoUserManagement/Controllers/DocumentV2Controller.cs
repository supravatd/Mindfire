using DemoUserManagement.Models;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static DemoUserManagement.Models.Model;

namespace DemoUserManagement.Controllers
{
    public class DocumentV2Controller : Controller
    {
        // GET: DocumentV2
        public ActionResult _DocumentPartialV2(int objectId, string sortBy, int draw = 1, int start = 0, int length = 3)
        {
            int pageSize = (int)length;
            int pageNumber = (int)(start / length) + 1;

            List<DocumentModel> docList = Business.Business.GetUploadedDocuments(pageNumber, pageSize, objectId, sortBy);

            int totalRecords = Business.Business.GetTotalDocuments(objectId);
            int filteredRecords = totalRecords;
            if (Request.IsAjaxRequest())
            {
                return Json(new
                {
                    draw = draw,
                    recordsTotal = totalRecords,
                    recordsFiltered = filteredRecords,
                    data = docList
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return PartialView("_DocumentPartialV2", docList);
            }

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