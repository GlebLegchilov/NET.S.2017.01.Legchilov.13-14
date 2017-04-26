using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task4;

namespace Task4Test
{
    [TestFixture]
    public class MatrixExtensionTest
    {

        public IEnumerable<TestCaseData> Sum_TestData
        {
            get
            {
                yield return new TestCaseData(new SquareMatrix<int>(new int[] { 1, 2, 3, 4 }), new SquareMatrix<int>(new int[] { 1, 2, 3, 4 }), new SquareMatrix<int>(new int[] { 2, 4, 6, 8 })).Returns(true);
                yield return new TestCaseData(new SquareMatrix<int>(new int[] { 1, 2, 3, 4 }), new SymmetricMatrix<int>(new int[] { 1, 2, 3 }), new SquareMatrix<int>(new int[] { 2, 4, 5, 7 })).Returns(true);
                yield return new TestCaseData(new SquareMatrix<int>(new int[] { 1, 2, 3, 4 }), new DiagonalMatrix<int>(new int[] { 1, 2 }), new SquareMatrix<int>(new int[] { 2, 2, 3, 6 })).Returns(true);
                yield return new TestCaseData(new SymmetricMatrix<int>(new int[] { 1, 2, 3 }), new SymmetricMatrix<int>(new int[] { 1, 2, 3 }), new SquareMatrix<int>(new int[] { 2, 4, 4, 6 })).Returns(true);
                yield return new TestCaseData(new SymmetricMatrix<int>(new int[] { 1, 2, 3 }), new DiagonalMatrix<int>(new int[] { 1, 2 }), new SquareMatrix<int>(new int[] { 2, 2, 2, 5 })).Returns(true);
                yield return new TestCaseData(new DiagonalMatrix<int>(new int[] { 1, 2 }), new DiagonalMatrix<int>(new int[] { 1, 2 }), new SquareMatrix<int>(new int[] { 2, 0, 0, 4 })).Returns(true);
            }
        }

        [Test, TestCaseSource("Sum_TestData")]
        public static bool Sum_Test(AbstractSquareMatrix<int> matrix1, AbstractSquareMatrix<int> matrix2, AbstractSquareMatrix<int> matrix3)
        {
            return matrix3.Equals(matrix1.Sum(matrix2, (x, y) => x + y));
        }

    }
}
