using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace NewsForYou.Utils
{
    public class Utils
    {
        public class SessionManager
        {
            public static bool GetSessionModel()
            {
                bool sessionValue = false;
                if (HttpContext.Current.Session["IsAuthenticated"] != null)
                {
                    sessionValue = (bool)HttpContext.Current.Session["IsAuthenticated"];
                }
                return sessionValue;
            }

            public static void SetSessionModel(bool session)
            {
                HttpContext.Current.Session["IsAuthenticated"] = session;
            }

        }
    }
}
