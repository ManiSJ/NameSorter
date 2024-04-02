using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorter.File
{
    public interface IFileManager
    {
        List<string> ReadAllLines(string filePath);
    }
}
