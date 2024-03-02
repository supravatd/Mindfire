using DemoUserManagement.Authorization;
using DemoUserManagement.Models;
using StudentLayers.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static DemoUserManagement.Models.Model;

namespace DemoUserManagement.Controllers
{
    [CustomAuthorize("Admin","User")]
    public class UserFormController : Controller
    {
        // GET: UserForm
        public ActionResult UserForm()
        {
            ViewBag.IsEditMode = false;

            List<CountryModel> countryList = Business.Business.GetCountryList();
            ViewBag.CountryList = new SelectList(countryList, "CountryId", "CountryName");

            return View(new UserModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserForm(UserModel model, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var uploadResult = HandleFileUpload(file);
                    model.FileGuid = uploadResult.Guid;
                    model.FileOriginal = uploadResult.Filename;

                    Business.Business.AddUserAddress(model, model.PresentAddress, model.PermanentAddress);
                    return RedirectToAction("Login","Login");
                }
                catch (Exception ex)
                {
                    Logger.AddData(ex);
                }
            }
            ViewBag.IsEditMode = false;
            List<CountryModel> countryList = Business.Business.GetCountryList();
            ViewBag.CountryList = new SelectList(countryList, "CountryId", "CountryName", model.PresentAddress.CountryId);
            ViewBag.CountryList = new SelectList(countryList, "CountryId", "CountryName", model.PermanentAddress.CountryId);

            return View(model);
        }

        public ActionResult GetStatesByCountry(int countryId)
        {
            var states = Business.Business.GetStateList(countryId);

            var stateList = states.Select(s => new SelectListItem
            {
                Value = s.StateId.ToString(),
                Text = s.StateName
            });

            return Json(stateList, JsonRequestBehavior.AllowGet);
        }

        private FileUploadModel HandleFileUpload(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                try
                {
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(file.FileName);
                    string uploadPath = Path.Combine(Server.MapPath("~/Uploads"), uniqueFileName);

                    file.SaveAs(uploadPath);
                    return new FileUploadModel
                    {
                        Guid = uniqueFileName,
                        Filename = Path.GetFileName(file.FileName)
                    };
                }
                catch (Exception ex)
                {
                    Logger.AddData(ex);
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public ActionResult EditUser(int id)
        {
            ViewBag.IsEditMode = true;
            ViewBag.UserId = id;
            UserModel user = Business.Business.GetUserById(id);

            List<CountryModel> countryList = Business.Business.GetCountryList();
            
            ViewBag.CountryList = new SelectList(countryList, "CountryId", "CountryName");
            
            return View("UserForm", user);
        }



    }
}