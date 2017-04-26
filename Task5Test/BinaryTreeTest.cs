using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5;
using NUnit.Framework;

namespace Task5Test
{
    [TestFixture]
    public class BinaryTreeTest
    {

        [Test]
        public void BinaryTreeInt_TestCompareAndCount()
        {
            BinaryTree<int> binaryTreeInt = new BinaryTree<int>() {1,2,3,4,5 };
            Assert.AreEqual(5, binaryTreeInt.Count);
        }

        [Test]
        public void BinaryTreeInt_TestCompareAndPrint()
        {
            int count = 0;
            BinaryTree<int> binaryTreeInt = new BinaryTree<int>(new IntComparer()) { 1, 2, 3, 4, 5 };
            var iterator = binaryTreeInt.Inorder();
            foreach (var item in iterator)
                count++;
            Assert.AreEqual(5, count);
        }

        [Test]
        public void BinaryTreeString_TestCompareAndCount()
        {
            BinaryTree<string> binaryTreeInt = new BinaryTree<string>() { "1", "2", "3", "4", "5" };
            Assert.AreEqual(5, binaryTreeInt.Count);
        }

        [Test]
        public void BinaryTreeString_TestCompareAndPrint()
        {
            int count = 0;
            BinaryTree<string> binaryTreeInt = new BinaryTree<string>(new StringComparer()) { "1", "2", "3", "4", "5" };
            var iterator = binaryTreeInt.Preorder();
            foreach (var item in iterator)
                count++;
            Assert.AreEqual(5, count);
        }

        [Test]
        public void BinaryTreeBook_TestCompareAndCount()
        {
            BinaryTree<Book> binaryTreeInt = new BinaryTree<Book>() { new Book("ada", 10), new Book("asasf", 20), new Book("affaac", 15) };
            Assert.AreEqual(3, binaryTreeInt.Count);
        }

        [Test]
        public void BinaryTreeBook_TestCompareAndPrint()
        {
            int count = 0;
            BinaryTree<Book> binaryTreeInt = new BinaryTree<Book>(new BooksComparer()) { new Book("ada", 10), new Book("asasf", 20), new Book("affaac", 15) };
            var iterator = binaryTreeInt.Postorder();
            foreach (var item in iterator)
                count++;
            Assert.AreEqual(3, count);
        }

        [Test]
        public void BinaryTreePoint_TestCompareAndCount()
        {
            BinaryTree<Point> binaryTreeInt = new BinaryTree<Point>(new PointComparer()) { new Point(1, 10), new Point(2, 20), new Point(3, 15) };
            Assert.AreEqual(3, binaryTreeInt.Count);
        }



    }
}
