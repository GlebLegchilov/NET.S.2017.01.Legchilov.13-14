﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    /// <summary>
    /// Class represents a binary search tree.
    /// </summary>
    /// <typeparam name="T">T is a type of binary search tree's elements.</typeparam>
    public sealed class BinaryTree<T> : ICollection<T>
    {

        #region Fields

        /// <summary>
        /// Main root of binary search tree.
        /// </summary>
        private Node head;
        /// <summary>
        /// Number of elements in binary search tree.
        /// </summary>
        private int count;
        /// <summary>
        /// Custom comparator.
        /// </summary>
        private IComparer<T> comparator;

        #endregion

        #region Properties

        /// <summary>
        /// Number of elements in binary search tree.
        /// </summary>
        public int Count
        {
            get
            {
                return count;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Count can't be less then zero.");

                count = value;
            }
        }

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
        /// Default constructor which sets a default value for the comparator.
        /// </summary>
        public BinaryTree() : this(Comparer<T>.Default) { }

        /// <summary>
        /// Constructor which takes custom comparator as an argument.
        /// </summary>
        public BinaryTree(IComparer<T> comparator, bool isReadOnly = false)
        {
            IsReadOnly = isReadOnly;
            head = null;
            Count = 0;
            this.comparator = comparator;
        }

        #endregion

     
        #region Public Methods

        /// <summary>
        /// This method adds elements to the binary search tree.
        /// </summary>
        /// <param name="value">Value which will be added.</param>
        public void Add(T value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            if (head == null)
            {
                head = new Node(value);
                Count++;
                return;
            }

            if (!Contains(value))
            {
                AddTo(head, value);
                Count++;
            }
        }

        /// <summary>
        /// This method finds binary search tree's node by given value.
        /// </summary>
        /// <param name="value">Value which one of nodes might contains.</param>
        /// <returns>Returns node if the binary search tree contains this value or null if it not.</returns>
        public Node FindByValue(T value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            if (head == null)
                throw new InvalidOperationException("Tree is empty!");

            return Find(head, value);
        }

        /// <summary>
        /// Display the data part of the root (or current node). Traverse the left subtree by recursively calling the pre-order function. Traverse the right subtree by recursively calling the pre-order function.
        /// </summary>
        /// <returns>Returns IEnumerable.</returns>
        public IEnumerable<T> Preorder()
        {
            if (ReferenceEquals(head, null))
                throw new InvalidOperationException("Tree is empty!");

            var roots = new Stack<Node>();

            Node current = head;

            while (true)
            {
                if (current != null)
                {
                    roots.Push(current);
                    yield return current.Value;
                    current = current.Left;
                }
                else
                {
                    if (roots.Any())
                        current = roots.Pop().Right;
                    else
                        break;
                }
            }
        }

        /// <summary>
        /// Traverse the left subtree by recursively calling the in-order function. Display the data part of the root (or current node). Traverse the right subtree by recursively calling the in-order function.
        /// </summary>
        /// <returns>Returns IEnumerable.</returns>
        public IEnumerable<T> Inorder()
        {
            if (ReferenceEquals(head, null))
                throw new InvalidOperationException("Tree is empty!");

            var roots = new Stack<Node>();

            var current = head;

            bool isDone = false;

            while (!isDone)
            {
                if (!ReferenceEquals(current, null))
                {
                    roots.Push(current);
                    current = current.Left;
                }
                else
                {
                    if (!roots.Any())
                    {
                        isDone = true;
                    }
                    else
                    {
                        current = roots.Pop();
                        yield return current.Value;
                        current = current.Right;
                    }
                }
            }
        }

        /// <summary>
        /// Post-order traversal with recursion. Traverse the left subtree by recursively calling the post-order function. Traverse the right subtree by recursively calling the post-order function. Display the data part of the root (or current node).
        /// </summary>
        /// <returns>Returns IEnumerable.</returns>
        public IEnumerable<T> Postorder()
        {
            return DoPostOrder(head);
        }

        #endregion

        #region ICollection implementation


        /// <summary>
        /// Clear the BST.
        /// </summary>
        public void Clear()
        {
            head = null;
            Count = 0;
        }

        /// <summary>
        /// This method determines BST contains given element or not.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Returns true if it contains given element.</returns>
        public bool Contains(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            if (FindByValue(item) != null)
                return true;

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="destinationArray"></param>
        /// <param name="startIndex"></param>
        public void CopyTo(T[] destinationArray, int startIndex)
        {
            if (ReferenceEquals(destinationArray, null))
                throw new ArgumentNullException(nameof(destinationArray));

            if (startIndex < 0)
                throw new ArgumentException("Start index can't be less than zero.");

            if (startIndex > destinationArray.Length)
                throw new ArgumentException("Start index can't be greater than lenght of destination array.");

            if ((destinationArray.Length - 1 - startIndex) < Count)
                throw new ArgumentException("Number of tree's elements is greater then given array range.");

            foreach (T item in Inorder())
            {
                destinationArray[startIndex] = item;
                startIndex++;
            }
        }

        /// <summary>
        /// This method returs enumerator.
        /// </summary>
        /// <returns>Returns IEnumerator.</returns>
        public IEnumerator<T> GetEnumerator() => Inorder().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <summary>
        /// Remove element in tree by the value.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(T item)
        {
            throw new NotSupportedException();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// This is helper method which use recursion for adding value to the binary search tree. 
        /// </summary>
        /// <param name="node">The node that will be used to determine on what go further subtree.</param>
        /// <param name="value">Value which will be added.</param>
        private void AddTo(Node node, T value)
        {
            if (comparator.Compare(value, node.Value) < 0)
            {
                if (node.Left == null)
                    node.Left = new Node(value);
                else
                    AddTo(node.Left, value);
            }
            else
            {
                if (node.Right == null)
                    node.Right = new Node(value);
                else
                    AddTo(node.Right, value);
            }
        }

        /// <summary>
        /// This is the helper method which is called by FindByValue method. 
        /// </summary>
        /// <param name="node">The node that will be used to determine on what go further subtree.</param>
        /// <param name="value">Seeking value.</param>
        /// <returns>Returns node if the binary search tree contains this value or null if it not.</returns>
        private Node Find(Node node, T value)
        {
            if (node == null)
                return null;

            if (comparator.Compare(node.Value, value) == 0)
                return node;

            if (comparator.Compare(node.Value, value) > 0)
                return Find(node.Left, value);

            return Find(node.Right, value);
        }

        /// <summary>
        /// This is the helper method which uses recurcion.
        /// </summary>
        /// <param name="node">Node for finding subtree.</param>
        /// <returns>Returns IEnumerable.</returns>
        private IEnumerable<T> DoPostOrder(Node node)
        {
            if (node == null)
            {
                yield break;
            }

            if (node.Left != null)
            {
                foreach (var leftNode in DoPostOrder(node.Left))
                {
                    yield return leftNode;
                }
            }

            if (node.Right != null)
            {
                foreach (var rightNode in DoPostOrder(node.Right))
                {
                    yield return rightNode;
                }
            }

            yield return node.Value;
        }

        #endregion

        #region inner-class Node

        /// <summary>
        /// This class represents a node of BST.
        /// </summary>
        public class Node
        {
            /// <summary>
            /// Left node.
            /// </summary>
            public Node Left { get; set; }
            /// <summary>
            /// Right node.
            /// </summary>
            public Node Right { get; set; }

            /// <summary>
            /// Value of the current node.
            /// </summary>
            public T Value
            {
                get
                {
                    return value;
                }
                private set
                {
                    if (value == null)
                        throw new ArgumentException("Value of tree's node can't be null.");

                    this.value = value;
                }
            }

            /// <summary>
            /// Default constructor.
            /// </summary>
            public Node() : this(default(T)) { }

            /// <summary>
            /// Value of the node.
            /// </summary>
            private T value;

            /// <summary>
            /// This constructor takes one parameter which will be represent the value of a node.
            /// </summary>
            /// <param name="value">Value which current node will contain.</param>
            public Node(T value)
            {
                Value = value;
            }

            /// <summary>
            /// Overrided ToString method.
            /// </summary>
            /// <returns>Representation of node in string foemat.</returns>
            public override string ToString()
            {
                if (Left == null)
                {
                    if (Right == null)
                        return $"Value: {value}, left: empty, right: empty.";

                    return $"Value: {value}, left: empty, right: {Right.Value}";
                }

                if (Right == null)
                    return $"Value: {value}, left: {Left.value}, right: empty.";

                return $"Value: {value}, left: {Left.value}, right: {Right.value}.";
            }          
        }

        #endregion

    }
}
