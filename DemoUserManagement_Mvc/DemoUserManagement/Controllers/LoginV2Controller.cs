using DemoUserManagement.Models;
using StudentLayers.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static DemoUserManagement.Models.Model;
using static DemoUserManagement.Utils.Utils;

namespace DemoUserManagement.Controllers
{
    public class LoginV2Controller : Controller
    {
        // GET: LoginV2
        public ActionResult LoginV2()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginV2(LoginModel model)
        {
            try
            {
                int userId = Business.Business.IsUser(model.Email, model.Password);
                bool isAdmin = Business.Business.IsAdmin(userId);

                if (userId > 0)
                {
                    SessionModel sessionValue = new SessionModel
                    {
                        UserId = userId,
                        IsAdmin = isAdmin
                    };
                    SessionManager.SetSessionModel(sessionValue);


                    return RedirectToAction("EditUserV2", "UserFormV2", new { id = sessionValue.UserId });

                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
                ModelState.AddModelError("", "An error occurred during login.");
            }

            return View(model);
        }
    }
}