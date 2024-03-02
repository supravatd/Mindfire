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
        public ActionResult UserListV2(int? page, string sortBy, string sortOrder)
        {
            int pageSize = 5;
            int pageNumber = page ?? 1;
            List<UserModel> userList = Business.Business.GetAllUsers(pageNumber, pageSize, sortBy, sortOrder);
            int totalUsers = Business.Business.GetTotalUsers();
            int totalPages = (int)Math.Ceiling((double)totalUsers / pageSize);

            if (Request.IsAjaxRequest())
            {
                return Json(new
                {
                    draw = pageNumber, 
                    recordsTotal = Business.Business.GetTotalUsers(),
                    recordsFiltered = userList.Count,
                    data = userList,
                    totalPages = totalPages
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return View();
            }
        }

    }
}