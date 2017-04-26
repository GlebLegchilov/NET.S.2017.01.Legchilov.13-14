using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public class SymmetricMatrix<T> : AbstractSquareMatrix<T>
    {
        #region Fields

        private readonly T[][] container;

        #endregion

        #region Constructors

        public SymmetricMatrix(int size)
        {
            Size = size;
            container = new T[Size][];

            for (int i = 0; i < Size; i++)
                container[i] = new T[i + 1];
        }

        public SymmetricMatrix(T[] array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            int sqrt = (int)Math.Round(((Math.Sqrt(8 * array.Length)) - 1) / 2);

            int sum = (int)((1d + sqrt) / 2d * sqrt);

            Size = (sum >= array.Length) ? sqrt : sqrt + 1;

            container = new T[Size][];

            for (int i = 0, h = 0; i < Size; i++)
            {
                container[i] = new T[i + 1];
                for (int j = 0; j <= i && h < array.Length; j++, h++)
                    container[i][j] = array[h];
            }
        }

        public SymmetricMatrix(T[][] array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            Size = array.Length;

            container = new T[Size][];

            for (int i = 0; i < array.Length; i++)
            {
                container[i] = new T[i + 1];
                for (int j = 0; j < array[i].Length && j <= i; j++)
                    container[i][j] = array[i][j];
            }
        }

        public SymmetricMatrix(T[,] array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            Size = array.GetLength(0);

            container = new T[Size][];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                container[i] = new T[i + 1];
                for (int j = 0; j < array.GetLength(1) && j <= i; j++)
                    container[i][j] = array[i, j];
            }
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
                return (j <= i) ? container[i][j] : container[j][i];
            }

            set
            {
                if (i > Size || j > Size || i <= 0 || j <= 0)
                    throw new IndexOutOfRangeException();

                i--; j--;

                if (j <= i)
                    container[i][j] = value;
                else
                    container[j][i] = value;

                OnValueChange(new ValueChangeEventArgs(++i, ++j));
            }
        }

        #endregion

        #region Public Methods

        public override IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    yield return (j <= i) ? container[i][j] : container[j][i];
        }

        #endregion
    }
}
