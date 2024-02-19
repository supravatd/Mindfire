using StudentLayers.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoUserManagement.Web
{
    public partial class _Default : Page
    {
        [WebMethod]
        public static object Login_Click(string email, string password)
        {
            try
            {
                int userId = Business.Business.IsUser(email, password);
                //Session["UserId"] = userId;
                if (userId > 0)
                {
                    return new { success = true, user = userId };
                }
                else
                {
                    return new { success = false, message = "Invalid email or password." };
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
                return new { success = false, message = "An error occurred during login." };
            }
        }
    }
}
