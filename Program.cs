using Microsoft.Extensions.DependencyInjection;
using NameSorter.File;
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

            var serviceProvider = DependencyServiceProvider.BuildServiceProvider();
            var sorter = serviceProvider.GetRequiredService<Sorter>();
            sorter.Sort(args[0]);            
        }
    }
}