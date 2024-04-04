using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorter.Sort
{
    public interface ISorter
    {
        void Sort(string[] args);

        List<string> SortNames(List<string> names);
    }
}
