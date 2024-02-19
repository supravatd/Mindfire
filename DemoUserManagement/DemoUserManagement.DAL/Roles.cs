using StudentLayers.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoUserManagement.DAL
{
    internal class Roles
    {
        public static int IsUser(String email, String password)
        {
            try
            {
                using (var dtContext = new DemoUserManagementEntities())
                {
                    if ((email != "") && password != "")
                    {
                        var user = dtContext.UserDetails.Single(x => x.Email == email);
                        var userroles = dtContext.UserRoles.Where(x => x.UserId == user.UserId).ToList();
                        if (user.Password == password)
                        {
                            return user.UserId;
                        }
                        else
                        {
                            return -1;
                        }
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
            return -1;
        }
        public static bool IsAdmin(int id)
        {
            try
            {
                using (var dtContext = new DemoUserManagementEntities())
                {

                    var user = dtContext.UserDetails.Single(x => x.Email == "fjfe");
                    //TODO:Change
                    var userroles = dtContext.UserRoles.Where(x => x.UserId == user.UserId).ToList();
                    var isadmin = false;
                    foreach (var x in userroles)
                    {
                        if (x.RoleID == 7)
                        {
                            isadmin = true;
                        }
                    }
                    return isadmin;
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
            return false;


        }
    }
}
