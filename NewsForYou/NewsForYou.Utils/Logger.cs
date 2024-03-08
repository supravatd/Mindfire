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
        public static void AddData(Exception e)
        {
            string filePath = ConfigurationManager.AppSettings["LogFilePath"] + DateTime.Now.ToString("dd-MM-yyyy") + ".txt";

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"[{DateTime.Now}]");
            }

            Exception currentException = e;
            while (currentException != null)
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine(currentException);
                    writer.WriteLine("--------------------------------------------------");
                }
                currentException = currentException.InnerException;
            }
        }
    }
}
