using StudentLayers.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using static DemoUserManagement.Models.Model;
using static DemoUserManagement.Utils.Utils;

namespace DemoUserManagement.Web
{
    public partial class _Default : BasePage
    {
        [WebMethod]
        public static object Login_Click(string email, string password)
        {
            try
            {
                int userId = Business.Business.IsUser(email, password);
                bool isAdmin = Business.Business.IsAdmin(userId);
                if (userId > 0)
                {
                    SessionModel sessionModel = new SessionModel
                    {
                        UserId = userId,
                        IsAdmin = isAdmin
                    };

                    SessionManager.SetSessionModel(sessionModel);
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
