using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static NewsForYou.Utils.Utils;

namespace NewsForYou.Web.Authorize
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var sessionValue = SessionManager.GetSessionModel();
            if (sessionValue == true)
            {
                if (filterContext.HttpContext.Session["Redirected"] == null)
                {
                    if (IsReportPage(filterContext.HttpContext.Request.Url.AbsoluteUri.ToLower()))
                    {
                        filterContext.Result = new RedirectResult("~/Report/ClickCountReport");
                        filterContext.HttpContext.Session["Redirected"] = true;
                    }
                    else if (IsAddCategoryPage(filterContext.HttpContext.Request.Url.AbsoluteUri.ToLower()))
                    {
                        filterContext.Result = new RedirectResult("~/AddCategory/AddCategory");
                        filterContext.HttpContext.Session["Redirected"] = true;
                    }
                }
            }
            else
            {
                if (IsReportPage(filterContext.HttpContext.Request.Url.AbsoluteUri.ToLower()))
                {
                    filterContext.Result = new RedirectResult("~/SignIn/SignIn");
                }
                else if (IsAddCategoryPage(filterContext.HttpContext.Request.Url.AbsoluteUri.ToLower()))
                {
                    filterContext.Result = new RedirectResult("~/SignIn/SignIn");
                }
            }
        }

        private bool IsReportPage(string url)
        {
            return url.Contains("report/clickcountreport");
        }

        private bool IsAddCategoryPage(string url)
        {
            return url.Contains("addcategory/addcategory");
        }
    }
}
