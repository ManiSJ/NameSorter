using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NameSorter.File
{
    public class FileManager : IFileManager
    {
        public FileManager()
        {
            
        }

        // Read the contents of the file into a list
        public List<string> ReadAllLines(string filePath)
        {
            return System.IO.File.ReadAllLines(filePath).ToList();
        }

        // Read the contents of the file into a list
        public void WriteAllLines(List<string> names)
        {
            System.IO.File.WriteAllLines("./sorted-names-list.txt.", names);
        }
    }
}
