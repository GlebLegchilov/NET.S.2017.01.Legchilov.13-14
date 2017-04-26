using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public interface IMatrixVisitor<T>
    {

        #region Methods

        void Visit(SquareMatrix<T> matrix);

        void Visit(SymmetricMatrix<T> matrix);

        void Visit(DiagonalMatrix<T> matrix);

        #endregion

    }
}
