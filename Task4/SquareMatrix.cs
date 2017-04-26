using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public class SquareMatrix<T> : AbstractSquareMatrix<T>
    {
        #region Fields

        private readonly T[,] container;

        #endregion

        #region Constructors

        public SquareMatrix(int size)
        {
            Size = size;
            container = new T[Size, Size];
        }

        public SquareMatrix(T[] array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            int sqrt = (int)Math.Sqrt(array.Length);

            Size = sqrt * sqrt < array.Length ? ++sqrt : sqrt;

            container = new T[Size, Size];

            for (int i = 0, h = 0; i < Size; i++)
                for (int j = 0; j < Size && h < array.Length; j++, h++)
                    container[i, j] = array[h];
        }

        public SquareMatrix(T[][] array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            Size = array.Length;

            foreach (T[] row in array)
                if (Size < row.Length)
                    Size = row.Length;

            container = new T[Size, Size];

            for (int i = 0; i < array.Length; i++)
                for (int j = 0; j < array[i].Length; j++)
                    container[i, j] = array[i][j];
        }

        public SquareMatrix(T[,] array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            Size = array.GetLength(0) >= array.GetLength(1) ? array.GetLength(0) : array.GetLength(1);

            container = new T[Size, Size];

            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j < array.GetLength(1); j++)
                    container[i, j] = array[i, j];
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
                return container[i, j];
            }

            set
            {
                if (i > Size || j > Size || i <= 0 || j <= 0)
                    throw new IndexOutOfRangeException();

                i--; j--;

                container[i, j] = value;

                OnValueChange(new ValueChangeEventArgs(++i, ++j));

            }
        }

        #endregion

        #region Public Methods

        public override IEnumerator<T> GetEnumerator()
        {
            foreach (var item in container)
                yield return item;
        }

        #endregion
    }
}
