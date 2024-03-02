using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static DemoUserManagement.Utils.Utils;
using System.Web.Mvc;
using DemoUserManagement.Controllers;

namespace DemoUserManagement.Authorization
{
    public class CustomAuthorizeV2Attribute : AuthorizeAttribute
    {
        private readonly string[] allowedRoles;

        public CustomAuthorizeV2Attribute(params string[] roles)
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
                        filterContext.Result = new RedirectResult("~UserListV2/UserListV2");
                    }
                    else
                    {
                        filterContext.Result = new RedirectResult("~/UserFormV2/EditUserV2/" + sessionModel.UserId);
                    }
                }
                else if (IsUserListPage(filterContext.HttpContext.Request.Url.AbsoluteUri.ToLower()))
                {
                    if (!isAdmin)
                    {
                        filterContext.Result = new RedirectResult("~/UserFormV2/EditUserV2/" + sessionModel.UserId);
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
                filterContext.Result = new RedirectResult("~/LoginV2/LoginV2");
            }

        }

        private void RedirectIfUnauthorized(AuthorizationContext filterContext, int userId)
        {
            string requestedUserId = filterContext.RouteData.Values["id"] as string;

            if (!string.IsNullOrEmpty(requestedUserId) && int.TryParse(requestedUserId, out int requestedId))
            {
                if (userId != requestedId)
                {
                    filterContext.Result = new RedirectResult("~/UserFormV2/EditUserV2/" + userId);
                }
            }
        }

        private bool IsLoginPage(string url)
        {
            return url.Contains("loginv2/loginv2");
        }

        private bool IsUserForm(string url)
        {
            return url.Contains("userformv2/edituserv2");
        }

        private bool IsUserListPage(string url)
        {
            return url.Contains("userlistv2/userlistv2");
        }
    }
}