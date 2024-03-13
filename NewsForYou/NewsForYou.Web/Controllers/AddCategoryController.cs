using System;
using System.Collections.Generic;
using System.Web.Mvc;
using NewsForYou.Business;
using NewsForYou.Utils;
using NewsForYou.Web.Authorize;
using static NewsForYou.Model.Model;

namespace NewsForYou.Web.Controllers
{
    [CustomAuthorize]
    public class AddCategoryController : Controller
    {
        // GET: AddCategory
        public ActionResult AddCategory()
        {
            return View();
        }

        public JsonResult AddAgency(string agencyName, string agencyFeedUrl)
        {
            try
            {
                AgencyModel agency = new AgencyModel
                {
                    AgencyName = agencyName,
                    AgencyLogoPath = agencyFeedUrl
                };

                int agencyId = Business.Business.AddAgency(agency);
                return Json(new { success = true, agencyId = agencyId });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return Json(new { success = false, error = ex.Message });
            }
        }

        public JsonResult AddNewCategory(string categoryTitle)
        {
            try
            {
                CategoryModel category = new CategoryModel
                {
                    CategoryTitle = categoryTitle,
                };

                int categoryId = Business.Business.AddCategory(category);
                return Json(new { success = true, categoryId = categoryId });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return Json(new { success = false, error = ex.Message });
            }
        }

        public JsonResult AddAgencyFeedUrl(string feedUrl, int agencyId, int categoryId)
        {
            try
            {
                AgencyFeedModel agencyFeed = new AgencyFeedModel
                {
                    AgencyFeedUrl = feedUrl,
                    AgencyId = agencyId,
                    CategoryId = categoryId
                };

                int agencyFeedId = Business.Business.AddAgencyFeed(agencyFeed);
                return Json(new { success = true, agencyFeedId = agencyFeedId });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return Json(new { success = false, error = ex.Message });
            }
        }

        public JsonResult DeleteAllNews()
        {
            try
            {
                Business.Business.DeleteAllNews();
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return Json(new { success = false, error = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult GetAgency()
        {
            var agencyList = Business.Business.GetAgencies();
            return Json(new { d = agencyList }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetCategory()
        {
            var categoryList = Business.Business.GetCategories();
            return Json(new { d = categoryList }, JsonRequestBehavior.AllowGet);
        }
    }
}
