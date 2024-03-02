using System;
using System.Web.Mvc;
using DemoUserManagement.Authorization;
using DemoUserManagement.Models;
using DemoUserManagement.Utils;
using StudentLayers.Utils;
using static DemoUserManagement.Models.Model;
using static DemoUserManagement.Utils.Utils;

namespace DemoUserManagement.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
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

                    if (isAdmin)
                    {
                        return RedirectToAction("UserList", "UserList");
                    }
                    else
                    {
                        return RedirectToAction("EditUser", "UserForm", new { id = sessionValue.UserId });
                    }
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
