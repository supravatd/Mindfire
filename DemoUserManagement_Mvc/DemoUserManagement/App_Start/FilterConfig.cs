using DemoUserManagement.Authorization;
using System.Web;
using System.Web.Mvc;

namespace DemoUserManagement
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new CustomAuthorizeAttribute());
            filters.Add(new CustomAuthorizeV2Attribute());

        }
    }
}
