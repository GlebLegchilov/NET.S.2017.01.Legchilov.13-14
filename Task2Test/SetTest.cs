using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2;
using NUnit.Framework;

namespace Task2Test
{

    [TestFixture]
    public class SetTest
    {

        private static Person[] TestData = new Person[] { new Person(1, "Василий"), new Person(2, "Пётр"), new Person(3, "Павел") };

        [Test]
        public void Add_LengCheck()
        {
            Set<Person> collection = new Set<Person>(TestData);
            collection.Add(new Person(4, "Иван"));
            Assert.AreEqual(4, collection.Count);
        }

        [Test]
        public void Remove_LengCheck()
        {
            Set<Person> collection = new Set<Person>(TestData);
            collection.Remove(new Person(2, "Пётр"));
            Assert.AreEqual(2, collection.Count);
        }



    }
}
