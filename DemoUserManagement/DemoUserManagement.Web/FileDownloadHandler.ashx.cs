using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace DemoUserManagement.Web
{
    /// <summary>
    /// Summary description for FileDownloadHandler
    /// </summary>
    public class FileDownloadHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
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

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}