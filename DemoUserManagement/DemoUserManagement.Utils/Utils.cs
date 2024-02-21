using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using static DemoUserManagement.Models.Model;

namespace DemoUserManagement.Utils
{
    public class Utils
    {
        public enum ObjectType
        {
            UserForm = 1,
        }

        public enum SortDirection
        {
            Ascending,
            Descending
        }

        public enum AddressType
        {
            Present = 0,
            Permanent = 1
        }

        public static class SessionManager
        {
            public static SessionModel GetSessionModel()
            {
                SessionModel sessionModel = HttpContext.Current.Session["SessionModel"] as SessionModel;
                return sessionModel ?? new SessionModel();
            }

            public static void SetSessionModel(SessionModel sessionModel)
            {
                HttpContext.Current.Session["SessionModel"] = sessionModel;
            }
        }
    }
}
