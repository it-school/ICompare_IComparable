using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda_1
{
    /*
    class Person : IComparable
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int CompareTo(object o)
        {
            return this.Name.CompareTo(((Person)o).Name);
        }
    }
    */
    
    class Person : IComparable<Person>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int CompareTo(Person p)
        {
            return this.Name.CompareTo(p.Name);
        }
    }

    class NameLengthComparer : IComparer<Person>
    {
        public int Compare(Person p1, Person p2)
        {
            if (p1.Name.Length > p2.Name.Length)
                return 1;
            else if (p1.Name.Length < p2.Name.Length)
                return -1;
            else
                return 0;
        }
    }

    class AgeComparer : IComparer<Person>
    {
        public int Compare(Person p1, Person p2)
        {
            if (p1.Age > p2.Age)
                return 1;
            else if (p1.Age < p2.Age)
                return -1;
            else
                return 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person { Name = "Сергей", Age = 34 };
            Person p2 = new Person { Name = "Алиса", Age = 23 };
            Person p3 = new Person { Name = "Аркадий", Age = 21 };
            Person p4 = new Person { Name = "Филип", Age = 22 };
            Person p5 = new Person { Name = "Михаил", Age = 26 };

            Person[] people = new Person[] { p1, p2, p3, p4, p5 };

            foreach (Person p in people)
                Console.WriteLine($"{p.Name} - {p.Age}");

            Console.WriteLine("Сортировка по алфавиту:");
            Array.Sort(people);

            foreach (Person p in people)
                Console.WriteLine($"{p.Name} - {p.Age}");

            Console.WriteLine();
            Console.WriteLine("Сортировка по длине имени:");

            Array.Sort(people, new NameLengthComparer());

            foreach (Person p in people)
                Console.WriteLine($"{p.Name} - {p.Age}");


            Console.WriteLine();
            Console.WriteLine("Сортировка по возрасту:");

            Array.Sort(people, new AgeComparer());

            foreach (Person p in people)
                Console.WriteLine($"{p.Name} - {p.Age}");


        }
    }
}
