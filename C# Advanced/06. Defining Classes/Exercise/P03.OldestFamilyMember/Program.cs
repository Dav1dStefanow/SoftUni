using System;
using System.Collections.Generic;

namespace P03.OldestFamilyMember
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int familyMembers = int.Parse(Console.ReadLine());
            List<Person> persons = new List<Person>();
            for(int i = 0; i < familyMembers;i++)
            {
                string[] familyMember = Console.ReadLine().Split();
                Person person = new Person(familyMember[0], int.Parse(familyMember[1]));
                persons.Add(person);
            }
            string oldestPersonName = string.Empty;
            int oldestPersonAge = 1;
            foreach(Person person in persons)
            {
                if(person.Age > oldestPersonAge)
                {
                    oldestPersonAge = person.Age;
                    oldestPersonName = person.Name;
                }
            }
            Console.WriteLine($"{oldestPersonName} {oldestPersonAge}");
        }
    }
}
