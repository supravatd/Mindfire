using System;
using System.Web;
using System.Web.Mvc;
using DemoUserManagement.Models;
using DemoUserManagement.Utils;
using static System.Collections.Specialized.BitVector32;
using static DemoUserManagement.Models.Model;
using static DemoUserManagement.Utils.Utils;

namespace DemoUserManagement.Authorization
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly string[] allowedRoles;

        public CustomAuthorizeAttribute(params string[] roles)
        {
            allowedRoles = roles;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {

            var sessionModel = SessionManager.GetSessionModel();
            bool isAdmin = sessionModel.IsAdmin;

            if (sessionModel != null && sessionModel.UserId != 0)
            {
                if (allowedRoles != null && allowedRoles.Length > 0)
                {
                    foreach (var role in allowedRoles)
                    {
                        if (role == "Admin" && isAdmin)
                        {
                            return;
                        }
                        else if (role == "User" && !isAdmin)
                        {
                            return;
                        }
                    }
                }

                if (IsLoginPage(filterContext.HttpContext.Request.Url.AbsoluteUri.ToLower()))
                {
                    if (isAdmin)
                    {
                        filterContext.Result = new RedirectResult("~/UserList/UserList");
                    }
                    else
                    {
                        filterContext.Result = new RedirectResult("~/UserForm/EditUser/" + sessionModel.UserId);
                    }
                }
                else if (IsUserListPage(filterContext.HttpContext.Request.Url.AbsoluteUri.ToLower()))
                {
                    if (!isAdmin)
                    {
                        filterContext.Result = new RedirectResult("~/UserForm/EditUser/" + sessionModel.UserId);
                    }
                }
                else if (IsUserForm(filterContext.HttpContext.Request.Url.AbsoluteUri.ToLower()))
                {
                    if (!isAdmin)
                    {
                        RedirectIfUnauthorized(filterContext, sessionModel.UserId);
                    }
                }
            }
            string requestedUser = filterContext.RouteData.Values["id"] as string;

            if (!string.IsNullOrEmpty(requestedUser) && int.TryParse(requestedUser, out int requestedId) && sessionModel.UserId == 0)
            {
                filterContext.Result = new RedirectResult("~/Login/Login");
            }

        }

        private void RedirectIfUnauthorized(AuthorizationContext filterContext, int userId)
        {
            string requestedUserId = filterContext.RouteData.Values["id"] as string;

            if (!string.IsNullOrEmpty(requestedUserId) && int.TryParse(requestedUserId, out int requestedId))
            {
                if (userId != requestedId)
                {
                    filterContext.Result = new RedirectResult("~/UserForm/EditUser/" + userId);
                }
            }
        }

        private bool IsLoginPage(string url)
        {
            return url.Contains("login/login");
        }

        private bool IsUserForm(string url)
        {
            return url.Contains("userform/edituser");
        }

        private bool IsUserListPage(string url)
        {
            return url.Contains("userlist/userlist");
        }
    }
}
