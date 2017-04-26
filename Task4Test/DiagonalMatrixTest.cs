using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4;
using NUnit.Framework;

namespace Task4Test
{
    [TestFixture]
    public class DiagonalMatrixTest
    {

        public IEnumerable<TestCaseData> ToString_TestData
        {
            get
            {
                yield return new TestCaseData(new DiagonalMatrix<int>(new int[] { 1, 2, 3, 4 })).Returns("1 0 0 0\n0 2 0 0\n0 0 3 0\n0 0 0 4");
                yield return new TestCaseData(new DiagonalMatrix<int>(new int[] { 1, 2, 3 })).Returns("1 0 0\n0 2 0\n0 0 3");
                yield return new TestCaseData(new DiagonalMatrix<int>(new int[] { 1, 2 })).Returns("1 0\n0 2");
                yield return new TestCaseData(new DiagonalMatrix<int>(new int[,] { { 1, 2 }, { 3, 4 } })).Returns("1 0\n0 4");
                yield return new TestCaseData(new DiagonalMatrix<int>(new int[][] { new int[] { 1, 2 }, new int[] { 3 } })).Returns("1 0\n0 0");
                yield return new TestCaseData(new DiagonalMatrix<int>(new int[][] { new int[] { 1 }, new int[] { 3 } })).Returns("1 0\n0 0");
            }
        }

        [Test, TestCaseSource("ToString_TestData")]
        public static string ToString_Test(DiagonalMatrix<int> matrix)
        {
            return matrix.ToString();
        }

        public IEnumerable<TestCaseData> GetEnumerator_TestData
        {
            get
            {
                yield return new TestCaseData(new DiagonalMatrix<int>(new int[] { 1, 2, 3, 4 })).Returns(16);
                yield return new TestCaseData(new DiagonalMatrix<int>(new int[] { 1, 2, 3 })).Returns(9);
                yield return new TestCaseData(new DiagonalMatrix<int>(new int[] { 1, 2 })).Returns(4);
                yield return new TestCaseData(new DiagonalMatrix<int>(new int[] { 1 })).Returns(1);
            }
        }

        [Test, TestCaseSource("GetEnumerator_TestData")]
        public static int GetEnumerator_Test(DiagonalMatrix<int> matrix)
        {
            int i = 0;
            foreach (var item in matrix)
            {
                i++;
            }

            return i;
        }

        public IEnumerable<TestCaseData> Size_TestData
        {
            get
            {
                yield return new TestCaseData(new DiagonalMatrix<int>(new int[] { 1, 2, 3, 4 })).Returns(4);
                yield return new TestCaseData(new DiagonalMatrix<int>(new int[] { 1, 2, 3 })).Returns(3);
                yield return new TestCaseData(new DiagonalMatrix<int>(new int[] { 1, 2 })).Returns(2);
                yield return new TestCaseData(new DiagonalMatrix<int>(new int[] { 1 })).Returns(1);
            }
        }

        [Test, TestCaseSource("Size_TestData")]
        public static int Size_Test(DiagonalMatrix<int> matrix)
        {
            return matrix.Size;
        }


        public IEnumerable<TestCaseData> Indexer_TestData
        {
            get
            {
                yield return new TestCaseData(new DiagonalMatrix<int>(new int[] { 1, 2, 3, 4 }), 1, 1, 0).Returns(0);
                yield return new TestCaseData(new DiagonalMatrix<int>(new int[] { 1, 2, 3 }), 2, 1, 7).Returns(0);
                yield return new TestCaseData(new DiagonalMatrix<int>(new int[] { 1, 2 }), 1, 2, 10).Returns(0);
                yield return new TestCaseData(new DiagonalMatrix<int>(new int[] { 1 }), 1, 1, 0).Returns(0);
            }
        }

        [Test, TestCaseSource("Indexer_TestData")]
        public static int Indexer_Test(DiagonalMatrix<int> matrix, int i, int j, int value)
        {
            matrix[i, j] = value;

            return matrix[i, j];
        }

        public IEnumerable<TestCaseData> Equals_TestData
        {
            get
            {
                yield return new TestCaseData(new DiagonalMatrix<int>(new int[] { 1, 2, 3, 4 }), new DiagonalMatrix<int>(new int[] { 1, 2, 3, 4 })).Returns(true);
                yield return new TestCaseData(new DiagonalMatrix<int>(new int[] { 1, 2 }), new DiagonalMatrix<int>(new int[] { 1, 2, 0 })).Returns(false);
                yield return new TestCaseData(new DiagonalMatrix<int>(new int[] { 1, 2 }), new DiagonalMatrix<int>(new int[] { 1, 2, 3 })).Returns(false);
                yield return new TestCaseData(new DiagonalMatrix<int>(new int[] { 1, 2 }), new SymmetricMatrix<int>(new int[] { 1, 0, 2 })).Returns(true);
                yield return new TestCaseData(new DiagonalMatrix<int>(new int[] { 1, 2 }), new SymmetricMatrix<int>(new int[] { 1, 2 })).Returns(false);
            }
        }

        [Test, TestCaseSource("Equals_TestData")]
        public static bool Equals_Test(DiagonalMatrix<int> matrix, AbstractSquareMatrix<int> matrix2)
        {
            return matrix.Equals(matrix2);
        }
    }
}
