using System;
using System.IO;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fileName = "data.txt";
            writeData(fileName);
            displayData(fileName);
            Console.Write("Enter data or exit? (enter/exit):");
            string option = Console.ReadLine().ToLower();
            while (option == "enter")
            {
                writeData(fileName);
                displayData(fileName);
                Console.Write("Enter data or exit? (enter/exit):");
                option = Console.ReadLine().ToLower();
            }
            Console.ReadLine();
        }

        private static void writeData(string fileName)
        {
            do
            {
                Console.WriteLine("Enter Data:");
                string data = Console.ReadLine();
                using (StreamWriter w = new StreamWriter(fileName, true))
                {
                    w.WriteLine(data);
                }
                Console.WriteLine("Do you want to add more data? (yes/no): ");
            }
            while (Console.ReadLine().ToLower() == "yes");
        }

        private static void displayData(string fileName)
        {
            if (File.Exists(fileName))
            {
                Console.WriteLine("File Data:");
                using (StreamReader r= new StreamReader(fileName))
                {
                    while(!r.EndOfStream)
                    {
                        Console.WriteLine(r.ReadLine());
                    }
                }
            }
            else
            {
                Console.WriteLine("No Data");
            }
        }
    }
}
