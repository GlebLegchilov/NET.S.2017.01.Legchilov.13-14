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
    public class Listener
    {
        public bool State { get; set; } = false;

        public void Register<T>(AbstractSquareMatrix<T> matrix)
        {
            matrix.ValueChange += MatrixMsg;
        }

        public void MatrixMsg(object sender, ValueChangeEventArgs e)
        {
            State = !State;
        }

        public void Unregister<T>(AbstractSquareMatrix<T> matrix)
        {
            matrix.ValueChange += MatrixMsg;
        }
    }

    public class SquareMatrixTest
    {

        public IEnumerable<TestCaseData> ToString_TestData
        {
            get
            {
                yield return new TestCaseData(new SquareMatrix<int>(new int[] { 1, 2, 3, 4 })).Returns("1 2\n3 4");
                yield return new TestCaseData(new SquareMatrix<int>(new int[] { 1, 2, 3 })).Returns("1 2\n3 0");
                yield return new TestCaseData(new SquareMatrix<int>(new int[] { 1, 2 })).Returns("1 2\n0 0");
                yield return new TestCaseData(new SquareMatrix<int>(new int[,] { { 1, 2 }, { 3, 4 } })).Returns("1 2\n3 4");
                yield return new TestCaseData(new SquareMatrix<int>(new int[][] { new int[] { 1, 2 }, new int[] { 3 } })).Returns("1 2\n3 0");
                yield return new TestCaseData(new SquareMatrix<int>(new int[][] { new int[] { 1 }, new int[] { 3 } })).Returns("1 0\n3 0");
            }
        }

        [Test, TestCaseSource("ToString_TestData")]
        public static string ToString_Test(SquareMatrix<int> matrix)
        {
            return matrix.ToString();
        }

        public IEnumerable<TestCaseData> GetEnumerator_TestData
        {
            get
            {
                yield return new TestCaseData(new SquareMatrix<int>(new int[] { 1, 2, 3, 4 })).Returns(4);
                yield return new TestCaseData(new SquareMatrix<int>(new int[] { 1, 2, 3 })).Returns(4);
                yield return new TestCaseData(new SquareMatrix<int>(new int[] { 1, 2 })).Returns(4);
                yield return new TestCaseData(new SquareMatrix<int>(new int[] { 1 })).Returns(1);
            }
        }

        [Test, TestCaseSource("GetEnumerator_TestData")]
        public static int GetEnumerator_Test(SquareMatrix<int> matrix)
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
                yield return new TestCaseData(new SquareMatrix<int>(new int[] { 1, 2, 3, 4 })).Returns(2);
                yield return new TestCaseData(new SquareMatrix<int>(new int[] { 1, 2, 3 })).Returns(2);
                yield return new TestCaseData(new SquareMatrix<int>(new int[] { 1, 2 })).Returns(2);
                yield return new TestCaseData(new SquareMatrix<int>(new int[] { 1 })).Returns(1);
            }
        }

        [Test, TestCaseSource("Size_TestData")]
        public static int Size_Test(SquareMatrix<int> matrix)
        {
            return matrix.Size;
        }

        public IEnumerable<TestCaseData> Indexer_TestData
        {
            get
            {
                yield return new TestCaseData(new SquareMatrix<int>(new int[] { 1, 2, 3, 4 }), 1, 1, 0).Returns(0);
                yield return new TestCaseData(new SquareMatrix<int>(new int[] { 1, 2, 3 }), 2, 1, 7).Returns(7);
                yield return new TestCaseData(new SquareMatrix<int>(new int[] { 1, 2 }), 1, 2, 10).Returns(10);
                yield return new TestCaseData(new SquareMatrix<int>(new int[] { 1 }), 1, 1, 0).Returns(0);
            }
        }

        [Test, TestCaseSource("Indexer_TestData")]
        public static int Indexer_Test(SquareMatrix<int> matrix, int i, int j, int value)
        {
            matrix[i, j] = value;

            return matrix[i, j];
        }

        public IEnumerable<TestCaseData> Equals_TestData
        {
            get
            {
                yield return new TestCaseData(new SquareMatrix<int>(new int[] { 1, 2, 3, 4 }), new SquareMatrix<int>(new int[] { 1, 2, 3, 4 })).Returns(true);
                yield return new TestCaseData(new SquareMatrix<int>(new int[] { 1, 2, 3 }), new SquareMatrix<int>(new int[] { 1, 2, 3, 0 })).Returns(true);
                yield return new TestCaseData(new SquareMatrix<int>(new int[] { 1, 2, 3 }), new DiagonalMatrix<int>(new int[] { 1, 2, 3 })).Returns(false);
                yield return new TestCaseData(new SquareMatrix<int>(new int[] { 1, 2, 2 }), new SymmetricMatrix<int>(new int[] { 1, 2 })).Returns(true);
                yield return new TestCaseData(new SquareMatrix<int>(new int[] { 1, 0, 2 }), new SymmetricMatrix<int>(new int[] { 1, 2 })).Returns(false);
            }
        }

        [Test, TestCaseSource("Equals_TestData")]
        public static bool Equals_Test(SquareMatrix<int> matrix, AbstractSquareMatrix<int> matrix2)
        {
            return matrix.Equals(matrix2);
        }

    }
}
