using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;
using NUnit.Framework;

namespace Task1Test
{
    [TestFixture]
    public class FibonacciNumbersTest
    {
        [TestCase(new uint[] {1, 1, 2, 3, 5, 8, 13, 21, 34, 55 })]
        public void GetSequence_PositivTest(uint[] array)
        {
            bool theSameSequence = true;
            int i = 0;
            foreach(var item in FibonacciNumbers.GetSequence())
            {
                if (i == array.Length) break;
                if (item != array[i++])
                {
                    theSameSequence = false;
                    break;
                }
            }
            Assert.IsTrue(theSameSequence);
        }
    }
}
