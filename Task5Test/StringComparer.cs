using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5Test
{
    class StringComparer: IComparer<string>
    {
        public int Compare(string x, string y)
        {
            if (x[0] == y[0]) return 0;
            if (x[0] > y[0]) return -1;
            return 1;
        }
    }
}
