using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspNetPractice
{
    public partial class LifeCycle : System.Web.UI.Page
    {

        protected void Page_PreInit(object sender, EventArgs e)
        {
            // Code for PreInit event
            Response.Write("PreInit event fired.<br/>");
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            // Code for Init event
            Response.Write("Init event fired.<br/>");
        }

        protected void Page_InitComplete(object sender, EventArgs e)
        {
            // Code for InitComplete event
            Response.Write("InitComplete event fired.<br/>");
        }

        protected void Page_PreLoad(object sender, EventArgs e)
        {
            // Code for PreLoad event
            Response.Write("PreLoad event fired.<br/>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Code for Load event
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            // Code to handle Button control's Click event
            Response.Write("Button Click event fired.<br/>");
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            // Code for LoadComplete event
            Response.Write("LoadComplete event fired.<br/>");
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Code for PreRender event
            Response.Write("PreRender event fired.<br/>");
        }

        protected void Page_PreRenderComplete(object sender, EventArgs e)
        {
            // Code for PreRenderComplete event
            Response.Write("PreRenderComplete event fired.<br/>");
        }

        protected void Page_SaveStateComplete(object sender, EventArgs e)
        {
            // Code for SaveStateComplete event
            Response.Write("SaveStateComplete event fired.<br/>");
        }

        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            // Code for Render event
            Response.Write("Render event fired.<br/>");
            base.Render(writer);
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            // Code for Unload event
            // Note: Response.Write() not recommended here as the response stream is closed
        }

        //Sequence:
        //PreInit
        //Init
        //InitComplete
        //PreLoad
        //Load     
        //LoadComplete
        //PreRender
        //PreRenderComplete
        //SaveStateComplete
        //Render
        //Page Unload

        //Then the page loads
        //Button Click occurs ofter the load event
    }
}