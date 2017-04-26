using System;
using System.Collections;
using System.Collections.Generic;

namespace Task2
{
    /// <summary>
    /// Class represents a general collection.
    /// </summary>
    /// <typeparam name="T">T is the type of collection's element</typeparam>
    public sealed class Set<T> : ICollection<T> where T: class
    {
        #region Filds

        /// <summary>
        /// Custom comparator.
        /// </summary>
        private IComparer<T> comparator;
        /// <summary>
        /// Container for collection
        /// </summary>
        private T[] container;
        #endregion

        #region Properties

        /// <summary>
        /// Number of elements in binary search tree.
        /// </summary>
        public int Count { get { return container.Length; } }

        /// <summary>
        /// Edit access
        /// </summary>
        public bool IsReadOnly { get; }

        /// <summary>
        /// Custom comparator.
        /// </summary>
        public IComparer<T> Comparator
        {
            get
            {
                return comparator;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));

                comparator = value;
            }
        }
        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor which sets a default value for the comparator and IsReadOnly propertie.
        /// </summary>
        /// <param name="isReadOnly"></param>
        public Set(bool isReadOnly = false )
        {
            IsReadOnly = isReadOnly;
            comparator = Comparer<T>.Default;
        }

        /// <summary>
        /// Constructor which takes array as an argument.
        /// </summary>
        public Set(T[] array, bool isReadOnly = false)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));
            comparator = Comparer<T>.Default;
            IsReadOnly = isReadOnly;
            container = array;
        }

        /// <summary>
        /// Constructor which takes custom comparator as an argument.
        /// </summary>
        public Set(IComparer<T> comparator, bool isReadOnly = false)
        {
            if (comparator == null) throw new ArgumentNullException(nameof(comparator));
            IsReadOnly = isReadOnly;
            this.comparator = comparator;
        }

        /// <summary>
        /// Constructor which takes custom comparator and array as an argument.
        /// </summary>
        public Set(T[] array, IComparer<T> comparator, bool isReadOnly = false)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));
            if (comparator == null) throw new ArgumentNullException(nameof(comparator));
            IsReadOnly = isReadOnly;
            this.comparator = comparator;
            container = array;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Add new element to collection
        /// </summary>
        /// <param name="item">New item</param>
        public void Add(T item)
        {
            if (IsReadOnly) throw new NotSupportedException("The object "+ nameof(Set<T>) + " is read-only.");
            if(item == null) throw new ArgumentNullException(nameof(item));
            Array.Resize<T>(ref container, container.Length + 1);
            container[container.Length - 1] = item;
        }

        /// <summary>
        /// Clear the collection
        /// </summary>
        public void Clear()
        {
            if (IsReadOnly) throw new NotSupportedException("The object " + nameof(Set<T>) + " is read-only.");
            Array.Resize<T>(ref container, 0);
        }

        /// <summary>
        /// This method determines collection contains given element or not.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Returns true if it contains given element.</returns>
        public bool Contains(T item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            return Array.Exists<T>(container, x => Equal(x, item));
        }

        /// <summary>
        /// Copy collection's elements to some array
        /// </summary>
        /// <param name="array">Target array</param>
        /// <param name="arrayIndex">Start index in target array</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));
            if (arrayIndex < 0) throw new ArgumentOutOfRangeException(nameof(arrayIndex));
            if ((array.Length - arrayIndex) < container.Length) throw new ArgumentException("The number of items in the source collection exceeds the available space, starting from the index to the end of the destination array");
            Array.Copy(array, arrayIndex, container, 0, container.Length);
        }

        /// <summary>
        /// Remove element in collection by the value.
        /// </summary>
        /// <param name="item">Item to remove</param>
        /// <returns>Returns true if removing successfully.</returns>
        public bool Remove(T item)
        {
            if (IsReadOnly) throw new NotSupportedException("The object " + nameof(Set<T>) + " is read-only.");
            if (item == null) throw new ArgumentNullException(nameof(item));
            int pos = Array.FindIndex<T>(container, x => Equal(x, item));
            if (pos == -1) return false;
            T[] newContainer = new T[container.Length -1];
            Array.Copy(newContainer, 0, container, 0, pos);
            Array.Copy(newContainer, pos, container, pos+1, container.Length - (pos+1));
            container = newContainer;
            return true;
        }

        /// <summary>
        /// This method returs enumerator.
        /// </summary>
        /// <returns>Returns IEnumerator.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in container)
                yield return item;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Eqaul two element by custom comparator
        /// </summary>
        /// <param name="x">First element</param>
        /// <param name="y">Second element</param>
        /// <returns>Returns true if elements are equal.</returns>
        private bool Equal(T x, T y)
        {
            if (Comparator.Compare(x, y) == 0) return true;
            return false;
        }
        #endregion

    }
}
