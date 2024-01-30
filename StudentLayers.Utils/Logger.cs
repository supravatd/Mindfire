using System;
using System.Configuration;
using System.IO;

namespace StudentLayers.Utils
{
    public class Logger
    {
        public static void AddData(Exception inputData, string fileName)
        {
            fileName = DateTime.Now.ToString("yyyyMMdd") + ".txt";
            string file = ConfigurationManager.AppSettings["LogFileFolderPath"];
            file = file + "\\" + fileName;
            using (StreamWriter writer = new StreamWriter(file, true))
            {
                writer.WriteLine(inputData);
            }
        }
    }
}
