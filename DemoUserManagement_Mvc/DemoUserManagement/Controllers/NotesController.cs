using DemoUserManagement.Models;
using StudentLayers.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoUserManagement.Controllers
{
    public class NotesController : Controller
    {
        // GET: Notes
        public ActionResult _NotesPartial(int objectId, int? page, string sortBy)
        {
            int pageSize = 3;
            int pageNumber = (page ?? 1);

            ViewBag.PageSize = pageSize;
            ViewBag.ObjectId = objectId;

            List<NoteModel> notes = Business.Business.GetAllNotes(pageNumber, pageSize, objectId,sortBy);
            var prevSortOrder = Request.QueryString["sortOrder"];

            ViewBag.SortBy = sortBy;
            ViewBag.SortOrder = prevSortOrder == "asc" ? "desc" : "asc";

            ViewBag.PageSize = pageSize;
            ViewBag.Notes = notes;

            return PartialView("_NotesPartial", ViewBag.Notes);
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
