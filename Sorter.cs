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

        public void Sort(string[] args)
        {
            var filePath = GenerateFilePath(args);
            var names = GetUnSortedNames(filePath);
            names = SortNames(names);
            ConsoleLogSortedNames(names);
            WriteSortedNames(names);
        }

        private string GenerateFilePath(string[] args)
        {
            // Check if the correct number of arguments is provided
            if (args.Length != 1)
            {
                Console.WriteLine("File name as argument needs to be provided");
                throw new Exception("File name as argument needs to be provided");
            }

            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;

            return Path.Combine(currentDirectory, args[0]);
        }

        private List<string> GetUnSortedNames(string filePath)
        {
            return _fileManager.ReadAllLines(filePath);
        }

        private List<string> SortNames(List<string> names)
        {
           return names
                .Select(p => new {  
                    firstWord = p.Split(' ').First(),
                    lastWord = p.Split(' ').Last(), 
                    fullWord = p })
                .OrderBy(p => p.lastWord)
                .ThenBy(p => p.firstWord)
                .Select(p => p.fullWord)
                .ToList();       
        }

        private void ConsoleLogSortedNames(List<string> names)
        {
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }

        private void WriteSortedNames(List<string> names)
        {
            _fileManager.WriteAllLines(names);
        }
    }
}
