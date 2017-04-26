using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5Test
{
    class Book: IComparable<Book>
    {
        public string Name { get; set; }
        public int Count { get; set; }

        public Book(string name, int count)
        {
            Name = name;
            Count = count;
        }

        public int CompareTo(Book y)
        {
            if (Count == y.Count) return 0;
            if (Count < y.Count) return -1;
            return 1;
        }

    }
}
