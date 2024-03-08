using NewsForYou.Web.Authorize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace NewsForYou.Web.Controllers
{
    [CustomAuthorize]
    public class ReportController : Controller
    {
        // GET: Report
        public ActionResult ClickCount()
        {
            return View();
        }

        public ActionResult ClickCountReport(DateTime startDate, DateTime endDate, int page = 1, int pageSize = 5, string sortBy = "AgencyName", string sortOrder = "asc")
        {
            var (reportData, totalPages) = Business.Business.GenerateClickCountReport(startDate, endDate, page, pageSize, sortBy, sortOrder);

            if (Request.IsAjaxRequest())
            {
                return Json(new { data = reportData, totalPages = totalPages }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return View(reportData);
            }
        }

        public JsonResult GeneratePdf(DateTime startDate,DateTime endDate)
        {
            var reportPdf= Business.Business.GeneratePdf(startDate, endDate);
            return Json(new { data = reportPdf}, JsonRequestBehavior.AllowGet);
        }
    }
}