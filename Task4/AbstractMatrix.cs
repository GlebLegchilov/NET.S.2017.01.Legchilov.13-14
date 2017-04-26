using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public abstract class AbstractSquareMatrix<T> : IEnumerable<T>, IEquatable<AbstractSquareMatrix<T>>, IVisitable<T>
    {
        public delegate void ValueChangeEventHandler(object sender, ValueChangeEventArgs e);

        #region Properties

        /// <summary>
        /// Matrix size.
        /// </summary>
        public int Size { get; protected set; }

        public abstract T this[int i, int j] { set; get; }

        #endregion

        #region Public Methods

        protected virtual void OnValueChange(ValueChangeEventArgs e)
        {
            ValueChange(this, e);
        }

        /// <summary>
        /// Accepting specified visitor.
        /// </summary>
        /// <param name="visitor"></param>
        public virtual void Accept(IMatrixVisitor<T> visitor)
        {
            if (visitor == null)
                throw new ArgumentNullException(nameof(visitor));

            visitor.Visit((dynamic)this);
        }

        #endregion

        #region IEquatable interface implementation

        /// <summary>
        /// Determines whether the specified matrix is equal to the current matrix.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(AbstractSquareMatrix<T> other)
        {
            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (this.Size != other.Size)
                return false;

            for (int i = 1; i <= this.Size; i++)
                for (int j = 1; j <= this.Size; j++)
                    if (!this[i, j].Equals(other[i, j]))
                        return false;

            return true;
        }

        #endregion

        #region IEnumerable interface implementation

        public abstract IEnumerator<T> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region Equals, GetHashCode, ToString

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null || this.GetType() != obj.GetType())
                return false;

            return this.Equals((AbstractSquareMatrix<T>)obj);
        }

        /// <summary>
        /// Returs the hashcode for this matrix.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        /// <summary>
        /// Returns string representation of this matrix.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string result = string.Empty;

            for (int i = 1; i <= Size; i++)
                for (int j = 1; j <= Size; j++)
                {
                    if (j != Size)
                        result += this[i, j].ToString() + " ";
                    else if (i != Size)
                        result += this[i, j].ToString() + "\n";
                    else
                        result += this[i, j].ToString();
                }

            return result;
        }

        #endregion

        #region Events

        /// <summary>
        /// On value change event.
        /// </summary>
        public event ValueChangeEventHandler ValueChange = delegate { };

        #endregion

    }

    public sealed class ValueChangeEventArgs : EventArgs
    {
        #region Constructors

        public ValueChangeEventArgs(int i, int j)
        {
            this.IndexI = i;
            this.IndexJ = j;
        }

        #endregion

        #region Properties

        public int IndexI { get; }
        public int IndexJ { get; }

        #endregion
    }
}
