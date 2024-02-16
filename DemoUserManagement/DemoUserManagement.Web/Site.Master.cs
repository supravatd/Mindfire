using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace DemoUserManagement.Web
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PageNameLabel.InnerText = Page.Title;
            if (!IsPostBack)
            {
                string pageName = Path.GetFileNameWithoutExtension(Page.AppRelativeVirtualPath);
                HtmlAnchor li = (HtmlAnchor)FindControl(pageName + "Link");
                if (li != null)
                {
                    li.Attributes.Add("class", "current");
                }
            }
        }
    }
}
