using DemoUserManagement.Authorization;
using DemoUserManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoUserManagement.Controllers
{
    [CustomAuthorizeV2("Admin")]
    public class UserListV2Controller : Controller
    {
        // GET: UserListV2
        public ActionResult UserListV2()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetUserListData(int draw, int start, int length)
        {
            int pageSize = length;
            int pageNumber = (start / length) + 1;
            var sortBy = Request.QueryString["sortOrder"];
            List<UserModel> userList = Business.Business.GetAllUsers(pageNumber, pageSize, sortBy);

            int totalRecords = Business.Business.GetTotalUsers();
            int filteredRecords = totalRecords;

            return Json(new
            {
                draw = draw,
                recordsTotal = totalRecords,
                recordsFiltered = filteredRecords,
                data = userList
            }, JsonRequestBehavior.AllowGet);
        }
    }
}