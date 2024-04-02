using NameSorter.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorter
{
    public class Sorter
    {
        private readonly IFileManager _fileManager;

        public Sorter(IFileManager fileManager)
        {
            _fileManager = fileManager;
        }

        public void Sort(string filePath)
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;

            string updatedFilePath = Path.Combine(currentDirectory, filePath);

            var names = _fileManager.ReadAllLines(updatedFilePath);

            names = SortByLastName(names);

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }

        private List<string> SortByLastName(List<string> names)
        {
           return names
                .Select(p => new { lastWord = p.Split(' ').Last(), fullWord = p })
                .OrderBy(p => p.lastWord)
                .Select(p => p.fullWord)
                .ToList();       
        }
    }
}
