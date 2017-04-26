using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Test
{
    public sealed class Person: IComparable<Person>
    {
        public int Age { get; }
        public string Name { get; }

        public Person(int age, string name)
        {
            Age = age;
            Name = name;
        }

        public int CompareTo(Person person)
        {
            if (person == null) throw new ArgumentNullException();
            if (person.Age < Age) return 1;
            if (person.Age > Age) return -1;
            return 0; 
        }
    }
}
