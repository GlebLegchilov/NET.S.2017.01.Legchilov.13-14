using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5Test
{
    class PointComparer: IComparer<Point>
    {
        public int Compare(Point x, Point y)
        {
            if (x.x == y.x) return 0;
            if (x.x < y.x) return -1;
            return 1;
        }
    }
}
