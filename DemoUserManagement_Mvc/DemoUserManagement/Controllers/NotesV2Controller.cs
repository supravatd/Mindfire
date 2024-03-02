using DemoUserManagement.Models;
using Newtonsoft.Json.Linq;
using StudentLayers.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoUserManagement.Controllers
{
    public class NotesV2Controller : Controller
    {
        // GET: NotesV2
        public ActionResult _NotesPartialV2(int objectId, int page = 1, int pageSize = 3, string sortBy = "NoteId")
        {
            List<NoteModel> notes = Business.Business.GetAllNotes(page, pageSize, objectId, sortBy);
            int totalNotes = Business.Business.GetTotalNotes(objectId);
            int totalPages = (int)Math.Ceiling((double)totalNotes / pageSize);

            if (Request.IsAjaxRequest())
            {
                return Json(new { notes = notes, totalPages = totalPages }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return PartialView("_NotesPartialV2", notes);
            }
        }


        [HttpPost]
        public JsonResult AddNotes(string noteData, int objectId, int objectType)
        {
            try
            {
                NoteModel note = new NoteModel
                {
                    ObjectId = objectId,
                    NoteData = noteData,
                    ObjectType = objectType,
                    DateTimeAdded = DateTime.Now.ToString("d")
                };

                Business.Business.AddNote(note);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
                return Json(new { success = false, error = ex.Message });
            }
        }
    }
}
