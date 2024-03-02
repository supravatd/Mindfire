using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static DemoUserManagement.Utils.Utils;

namespace DemoUserManagement.Controllers
{
    public class LogoutController : Controller
    {
        // GET: Logout
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Login");
        }
    }
}