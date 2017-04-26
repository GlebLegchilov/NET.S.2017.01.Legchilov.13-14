using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public class SumMatrixVisitor<T> : IMatrixVisitor<T>
    {

        #region Fields

        AbstractSquareMatrix<T> matrixB;
        AbstractSquareMatrix<T> sum;
        Func<T, T, T> sumFunction;

        #endregion

        #region Constructors

        public SumMatrixVisitor(AbstractSquareMatrix<T> matrixB, Func<T, T, T> sumFunction)
        {
            MatrixB = matrixB;
            SumFunction = sumFunction;
        }

        #endregion

        #region Properties

        public AbstractSquareMatrix<T> Sum
        {
            get
            {
                if (sum == null)
                    throw new InvalidOperationException();

                return sum;
            }
            private set
            {
                sum = value;
            }
        }

        public AbstractSquareMatrix<T> MatrixB
        {
            get { return matrixB; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException();

                matrixB = value;
            }
        }

        public Func<T, T, T> SumFunction
        {
            get
            { return sumFunction; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException();

                sumFunction = value;
            }
        }

        #endregion

        #region Public Methods

        public void Visit(DiagonalMatrix<T> matrix)
        {
            Sum = SumMatrix(matrix, matrixB);
        }

        public void Visit(SymmetricMatrix<T> matrix)
        {
            Sum = SumMatrix(matrix, matrixB);
        }

        public void Visit(SquareMatrix<T> matrix)
        {
            Sum = SumMatrix(matrix, matrixB);
        }

        #endregion

        #region Private Methods

        private AbstractSquareMatrix<T> SumMatrix(AbstractSquareMatrix<T> matrixFirst, AbstractSquareMatrix<T> matrixSecond)
        {
            if (matrixFirst == null)
                throw new ArgumentNullException(nameof(matrixFirst));
            if (matrixSecond == null)
                throw new ArgumentNullException(nameof(matrixSecond));
            if (matrixFirst.Size != matrixSecond.Size)
                throw new ArgumentException();

            SquareMatrix<T> resultMatrix = new SquareMatrix<T>(matrixFirst.Size);

            for (int i = 1; i <= matrixFirst.Size; i++)
                for (int j = 1; j <= matrixFirst.Size; j++)
                    resultMatrix[i, j] = SumFunction(matrixFirst[i, j], matrixSecond[i, j]);

            return resultMatrix;
        }

        #endregion
    }
}
