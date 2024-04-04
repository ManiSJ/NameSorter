using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using NameSorter.File;
using NameSorter.Sort;

namespace NameSorter
{
    public static class DependencyServiceProvider
    {
        public static ServiceProvider BuildServiceProvider()
        {
            return new ServiceCollection()
                   .AddTransient<IFileManager, FileManager>()
                   .AddTransient<ISorter, Sorter>()
                   .BuildServiceProvider();
        }
    }
}
