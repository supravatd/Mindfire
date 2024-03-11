using NewsForYou.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static NewsForYou.Model.Model;
using static NewsForYou.Utils.Utils;

namespace NewsForYou.Web.Controllers
{
    public class SignInController : Controller
    {
        // GET: SignIn
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(SignInModel model)
        {
            try
            {
                int userId = Business.Business.IsUser(model.Email, model.Password);
                if (userId > 0)
                {
                    SessionManager.SetSessionModel(true);
                    return RedirectToAction("Agency", "AgencyList");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid email or password.");
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
                ModelState.AddModelError("", "An error occurred. Please try again.");
            }
            return View(model);
        }
    }
}