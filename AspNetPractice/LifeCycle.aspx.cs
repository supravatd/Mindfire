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
            System.Diagnostics.Trace.WriteLine("PreInit event fired.<br/>");
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            // Code for Init event
            System.Diagnostics.Trace.WriteLine("Init event fired.<br/>");
        }

        protected void Page_InitComplete(object sender, EventArgs e)
        {
            // Code for InitComplete event
            System.Diagnostics.Trace.WriteLine("InitComplete event fired.<br/>");
        }

        protected void Page_PreLoad(object sender, EventArgs e)
        {
            // Code for PreLoad event
            System.Diagnostics.Trace.WriteLine("PreLoad event fired.<br/>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Code for Load event
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            // Code to handle Button control's Click event
            System.Diagnostics.Trace.WriteLine("Button Click event fired.<br/>");
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            // Code for LoadComplete event
            System.Diagnostics.Trace.WriteLine("LoadComplete event fired.<br/>");
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Code for PreRender event
            System.Diagnostics.Trace.WriteLine("PreRender event fired.<br/>");
        }

        protected void Page_PreRenderComplete(object sender, EventArgs e)
        {
            // Code for PreRenderComplete event
            System.Diagnostics.Trace.WriteLine("PreRenderComplete event fired.<br/>");
        }

        protected void Page_SaveStateComplete(object sender, EventArgs e)
        {
            // Code for SaveStateComplete event
            System.Diagnostics.Trace.WriteLine("SaveStateComplete event fired.<br/>");
        }

        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            // Code for Render event
            System.Diagnostics.Trace.WriteLine("Render event fired.<br/>");
            base.Render(writer);
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            // Code for Unload event
            // Note: System.Diagnostics.Trace.WriteLine() not recommended here as the response stream is closed
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