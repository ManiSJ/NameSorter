using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NameSorter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Check if the correct number of arguments is provided
            if (args.Length != 1)
            {
                Console.WriteLine("File name as argument needs to be provided");
                return;
            }

            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // Specify the file path
            string filePath = Path.Combine(currentDirectory, args[0]);

            // Read the contents of the file into a list
            List<string> nameList = File.ReadAllLines(filePath).ToList();

            foreach (var name in nameList)
            {
                Console.WriteLine(name);
            }
        }
    }
}