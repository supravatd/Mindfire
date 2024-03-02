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
    [CustomAuthorizeV2("Admin","User")]
    public class UserFormV2Controller : Controller
    {
        // GET: UserFormV2
        public ActionResult UserFormV2()
        {
            ViewBag.IsEditMode = false;
            return View(new UserModel());
        }

        [HttpGet]
        public ActionResult GetCountryList()
        {
            List<CountryModel> countryList = Business.Business.GetCountryList();
            return Json(countryList, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult UserFormV2(UserModel model, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var uploadResult = HandleFileUpload(file);
                    model.FileGuid = uploadResult.Guid;
                    model.FileOriginal = uploadResult.Filename;

                    Business.Business.AddUserAddress(model, model.PresentAddress, model.PermanentAddress);
                    return RedirectToAction("LoginV2", "LoginV2");
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

        public ActionResult EditUserV2(int id)
        {
            try
            {
                ViewBag.IsEditMode = true;
                ViewBag.UserId = id;

                UserModel user = Business.Business.GetUserById(id);

                List<CountryModel> countryList = Business.Business.GetCountryList();

                ViewBag.CountryList = new SelectList(countryList, "CountryId", "CountryName");

                if (Request.IsAjaxRequest())
                {
                    return Json(user, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return View("UserFormV2", user);
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
                throw;
            }
        }

        [HttpPost]
        public JsonResult EmailExists(string email)
        {
            bool exists = Business.Business.EmailExists(email);
            return Json(new { exists });
        }

        [HttpPost]
        public JsonResult CheckUserEmail(string userId, string email)
        {
            bool valid = Business.Business.CheckUserEmail(userId, email);
            return Json(new { valid });
        }

    }
}