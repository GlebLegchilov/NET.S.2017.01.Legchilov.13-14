using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public class DiagonalMatrix<T> : AbstractSquareMatrix<T>
    {
        #region Fields

        private readonly T[] container;

        #endregion

        #region Constructors

        public DiagonalMatrix(int size)
        {
            Size = size;
            container = new T[Size];
        }

        public DiagonalMatrix(T[] array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            Size = array.Length;

            container = new T[array.Length];

            for (int i = 0; i < Size; i++)
                container[i] = array[i];
        }

        public DiagonalMatrix(T[][] array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            Size = array.Length;

            foreach (T[] row in array)
                if (Size < row.Length)
                    Size = row.Length;

            container = new T[Size];

            for (int i = 0; i < array.Length; i++)
                for (int j = 0; j < array[i].Length; j++)
                    if (i == j)
                        container[i] = array[i][j];
        }

        public DiagonalMatrix(T[,] array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            Size = array.GetLength(0) >= array.GetLength(1) ? array.GetLength(0) : array.GetLength(1);

            container = new T[Size];

            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j < array.GetLength(1); j++)
                    if (i == j)
                        container[i] = array[i, j];
        }

        #endregion

        #region Properties

        public override T this[int i, int j]
        {
            get
            {
                if (i > Size || j > Size || i <= 0 || j <= 0)
                    throw new IndexOutOfRangeException();

                i--; j--;
                if (i == j)
                    return container[i];
                else
                    return default(T);
            }

            set
            {
                if (i > Size || j > Size || i <= 0 || j <= 0)
                    throw new IndexOutOfRangeException();

                i--; j--;
                if (i == j)
                    container[i] = value;

                OnValueChange(new ValueChangeEventArgs(++i, ++j));
            }
        }

        #endregion

        #region Public Methods

        public override IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    yield return (i == j) ? container[i] : default(T);
        }

        #endregion
    }
}
