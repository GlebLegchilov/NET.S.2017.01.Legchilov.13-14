using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    /// <summary>
    /// Class return Fibonacci's sequence
    /// </summary>
    public static class FibonacciNumbers
    {
        /// <summary>
        /// Return Fibonacci's sequence
        /// </summary>
        /// <returns>Fibonacci's sequence</returns>
        public static IEnumerable<uint> GetSequence()
        {
            uint first = 1 , second = 1, result;
            yield return first;
            yield return second;
            while (true)
            {
                yield return result = first + second;
                first = second;
                second = result; 
            }
        }

    }
}
