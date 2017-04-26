using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5Test
{
    class BooksComparer : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            if (x.Count == y.Count) return 0;
            if (x.Count > y.Count) return -1;
            return 1;
        }
    }
}
