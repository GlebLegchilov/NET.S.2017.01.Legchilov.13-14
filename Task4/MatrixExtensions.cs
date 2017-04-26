using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public static class MatrixExtensions
    {

        #region Public Methods

        /// <summary>
        /// Returns sum of two matrixcies by specified function.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="matrixA"></param>
        /// <param name="matrixB"></param>
        /// <param name="sumFunction"></param>
        /// <returns></returns>
        public static AbstractSquareMatrix<T> Sum<T>(this AbstractSquareMatrix<T> matrixA, AbstractSquareMatrix<T> matrixB, Func<T, T, T> sumFunction)
        {
            SumMatrixVisitor<T> visitor = new SumMatrixVisitor<T>(matrixB, sumFunction);

            matrixA.Accept(visitor);

            return visitor.Sum;
        }

        #endregion

    }
}
