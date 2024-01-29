using System;
using System.Configuration;
using System.IO;

namespace EntityFramework
{
    internal class Logger
    {
        public static void AddData(Exception inputData, String fileName)
        {
            string file = ConfigurationManager.AppSettings["LogFileFolderPath"];
            file = file + "\\" + fileName;
            using (StreamWriter writer = new StreamWriter(file, true))
            {
                writer.WriteLine(inputData);
            }
        }
    }
}