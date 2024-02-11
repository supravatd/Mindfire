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
            string filePath = ConfigurationManager.AppSettings["LogFilePath"] + DateTime.Now.ToString("yyyMMdd") + ".txt";
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(e);
            }
        }
    }
}
