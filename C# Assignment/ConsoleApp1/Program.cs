﻿using System;
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

            Console.Write("Enter Data/Display Data/Exit (enter/display/exit): ");
            string option = Console.ReadLine().ToLower();

            while (option != "exit")
            {
                if (option == "enter")
                {
                    writeData(fileName);
                    displayData(fileName);
                }
                else if (option == "display")
                {
                    displayData(fileName);
                }
                else
                {
                    Console.WriteLine("Invalid option. Please enter 'enter', 'display', or 'exit'.");
                }

                Console.Write("Enter Data/Display Data/Exit (enter/display/exit): ");
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
                Console.Write("Do you want to add more data? (yes/no): ");
            }
            while (Console.ReadLine().ToLower() == "yes");
        }

        private static void displayData(string fileName)
        {
            if (File.Exists(fileName))
            {
                Console.WriteLine("File Data:");
                using (StreamReader r = new StreamReader(fileName))
                {
                    while (!r.EndOfStream)
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