using Microsoft.Extensions.DependencyInjection;
using NameSorter.File;
using NameSorter.Sort;
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
            var serviceProvider = DependencyServiceProvider.BuildServiceProvider();
            var sorter = serviceProvider.GetRequiredService<ISorter>();
            sorter.Sort(args);            
        }
    }
}