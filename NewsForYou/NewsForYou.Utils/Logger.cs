using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsForYou.Utils
{
    public class Logger
    {
        public static void LogError(Exception e)
        {
            string logFilePath = ConfigurationManager.AppSettings["LogFilePath"];
            string filePath = Path.Combine(logFilePath, DateTime.Now.ToString("dd-MM-yyyy") + ".txt");

            if (!Directory.Exists(logFilePath))
            {
                Directory.CreateDirectory(logFilePath);
            }

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"[{DateTime.Now}]");

                Exception currentException = e;
                while (currentException != null)
                {
                    writer.WriteLine(currentException);
                    writer.WriteLine("--------------------------------------------------");
                    currentException = currentException.InnerException;
                }
            }

           
        }
    }
}
