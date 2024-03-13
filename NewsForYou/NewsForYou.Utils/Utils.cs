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
            public static bool IsAuthenticated
            {
                get
                {
                    if (HttpContext.Current.Session["IsAuthenticated"] != null)
                    {
                        return (bool)HttpContext.Current.Session["IsAuthenticated"];
                    }
                    else
                    {
                        return false;
                    }
                }
                set
                {
                    HttpContext.Current.Session["IsAuthenticated"] = value;
                }
            }
        }
    }
}
