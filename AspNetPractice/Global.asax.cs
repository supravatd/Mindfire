using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace AspNetPractice
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            System.Diagnostics.Trace.WriteLine("Application_Start");
        }

        protected void Application_End(object sender, EventArgs e)
        {
            System.Diagnostics.Trace.WriteLine("Application_End");
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            System.Diagnostics.Trace.WriteLine("Application_Error");
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            System.Diagnostics.Trace.WriteLine("Session_Start");
        }

        protected void Session_End(object sender, EventArgs e)
        {
            System.Diagnostics.Trace.WriteLine("Session_End");
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            System.Diagnostics.Trace.WriteLine("Application_BeginRequest");
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            System.Diagnostics.Trace.WriteLine("Application_EndRequest");
        }

        protected void Application_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            System.Diagnostics.Trace.WriteLine("Application_PreRequestHandlerExecute");
        }

        protected void Application_PostRequestHandlerExecute(object sender, EventArgs e)
        {
            System.Diagnostics.Trace.WriteLine("Application_PostRequestHandlerExecute");
        }

        protected void Application_PreSendRequestHeaders(object sender, EventArgs e)
        {
            System.Diagnostics.Trace.WriteLine("Application_PreSendRequestHeaders");
        }

        protected void Application_PreSendRequestContent(object sender, EventArgs e)
        {
            System.Diagnostics.Trace.WriteLine("Application_PreSendRequestContent");
        }

        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            System.Diagnostics.Trace.WriteLine("Application_AcquireRequestState");
        }

        protected void Application_ReleaseRequestState(object sender, EventArgs e)
        {
            System.Diagnostics.Trace.WriteLine("Application_ReleaseRequestState");
        }

        protected void Application_ResolveRequestCache(object sender, EventArgs e)
        {
            System.Diagnostics.Trace.WriteLine("Application_ResolveRequestCache");
        }

        protected void Application_UpdateRequestCache(object sender, EventArgs e)
        {
            System.Diagnostics.Trace.WriteLine("Application_UpdateRequestCache");
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            System.Diagnostics.Trace.WriteLine("Application_AuthenticateRequest");
        }

        protected void Application_AuthorizeRequest(object sender, EventArgs e)
        {
            System.Diagnostics.Trace.WriteLine("Application_AuthorizeRequest");
        }
    }
}