using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using static DemoUserManagement.Models.Model;
using static DemoUserManagement.Utils.Utils;

namespace DemoUserManagement.Web
{
    /// <summary>
    /// Summary description for FileDownloadHandler
    /// </summary>
    public class FileDownloadHandler : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            int objectId = int.Parse(context.Request.Params["ObjectId"]);
            SessionModel session = SessionManager.GetSessionModel();
            if (!session.IsAdmin)
            {
                if (session.UserId == objectId)
                {
                    string filename = context.Request.Params["fileName"];
                    string filePath = HttpContext.Current.Server.MapPath("~/UploadDocuments") + "\\" + filename;
                    FileInfo file = new FileInfo(filePath);

                    if (file.Exists)
                    {
                        context.Response.Clear();
                        context.Response.AddHeader("Content-Disposition", "inline; filename=" + file.Name);
                        context.Response.ContentType = "application/octet-stream";
                        context.Response.TransmitFile(file.FullName);
                        context.Response.Flush();
                    }
                    else
                    {
                        context.Response.ContentType = "text/plain";
                        context.Response.Write("File not be found!");
                    }
                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}