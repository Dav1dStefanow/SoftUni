﻿using System;
using System.Collections.Generic;

namespace P06.EqualityLogic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int ammountOfPersons = int.Parse(Console.ReadLine());
            var sortedSet = new SortedSet<Person>();
            var hashSet = new HashSet<Person>();
            for (int i = 0; i < ammountOfPersons; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                var person = new Person(name, age);
                sortedSet.Add(person);
                hashSet.Add(person);
            }
            Console.WriteLine(sortedSet.Count);
            Console.WriteLine(hashSet.Count);
        }
    }
}
