using System;
using System.Collections.Generic;

namespace P05.ComparingObjects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string command = "";
            while ((command = Console.ReadLine()) != "END")
            {
                string[] tokens = command.Split(' ');
                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                string town = tokens[2];
                Person person = new Person(name, age, town);
                people.Add(person);
            }
            var index = int.Parse(Console.ReadLine()) - 1;
            var equal = 0;
            var notequal = 0;
            foreach (Person person in people)
            {
                if (people[index].CompareTo(person) == 0)
                {
                    equal++;
                }
                else
                {
                    notequal++;
                }
            }
            if(equal <= 1 )
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{equal} {notequal} {people.Count}");
            }
        }
    }
}
