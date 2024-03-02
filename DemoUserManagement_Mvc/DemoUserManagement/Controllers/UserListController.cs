using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoUserManagement.Authorization;
using DemoUserManagement.Models;
using static DemoUserManagement.Models.Model;

namespace DemoUserManagement.Controllers
{
    [CustomAuthorize("Admin")]
    public class UserListController : Controller
    {
        // GET: UserList
        public ActionResult UserList(int? page, string sortBy)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            var prevSortOrder = Request.QueryString["sortOrder"];
            List<UserModel> userList = Business.Business.GetAllUsers(pageNumber, pageSize,sortBy);


            ViewBag.SortBy = sortBy;
            ViewBag.SortOrder = prevSortOrder == "asc" ? "desc" : "asc";

            ViewBag.PageSize = pageSize;

            return View(userList);
        }
    }
}