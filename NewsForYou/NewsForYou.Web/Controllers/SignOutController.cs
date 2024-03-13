using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static NewsForYou.Utils.Utils;

namespace NewsForYou.Web.Controllers
{
    public class SignOutController : Controller
    {
        // GET: SignOut
        public ActionResult SignOut()
        {
            SessionManager.IsAuthenticated = false;
            return RedirectToAction("SignIn", "SignIn");
        }
    }
}