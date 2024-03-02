using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Web;

namespace StudentLayers.Utils
{
    public class Logger
    {
        public static void AddData(Exception e)
        {
            string filePath = ConfigurationManager.AppSettings["LogFilePath"] + DateTime.Now.ToString("yyyyMMdd") + ".txt";
            WriteExceptionToFile(e, filePath);
        }

        private static void WriteExceptionToFile(Exception e, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                writer.WriteLine("Exception: " + e.GetType().FullName);
                writer.WriteLine("Message: " + e.Message);
                writer.WriteLine("StackTrace: " + e.StackTrace);
                writer.WriteLine("Source: " + e.Source);

                if (e.InnerException != null)
                {
                    writer.WriteLine("Inner Exception:");
                    WriteExceptionToFile(e.InnerException, filePath);
                }
            }
        }
    }
}
