using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static NewsForYou.Model.Model;

namespace NewsForYou.Web.Controllers
{
    public class FeedController : Controller
    {
        // GET: Feed
        public ActionResult NewsFeed(int agencyId)
        {
            var categories = Business.Business.GetCategoriesByAgencyId(agencyId);
            var allNews = Business.Business.GetAllNews(agencyId);
            if (Request.IsAjaxRequest())
            {
                // Return JSON response for AJAX request
                return Json(new { NewsData = allNews}, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return View(categories);
            }
        }

        public ActionResult GetNewsByCategories(List<int> categories, int agencyId)
        {
            List<NewsDataViewModel> newsData = new List<NewsDataViewModel>();
            bool newsAdded = false;

            if (categories != null && categories.Any())
            {
                var result = Business.Business.GetNewsByCategories(categories, agencyId);
                newsData = result.newsData;
                newsAdded = result.newsAdded;
            }
            else
            {
                newsData = Business.Business.GetAllNews(agencyId);
            }

            if (Request.IsAjaxRequest())
            {
                return Json(new { NewsData = newsData, NewDataAdded = newsAdded }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                ViewBag.NewDataAdded = newsAdded;
                return View("NewsFeed", newsData);
            }
        }

        public ActionResult IncrementClickCount(int newsId)
        {
            Business.Business.IncrementNewsClickCount(newsId);
            return Json(new { success = true });
        }
    }
}