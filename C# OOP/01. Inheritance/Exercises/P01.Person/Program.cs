using P01.Person.People;
using System;

namespace P01.Person
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            Child child = new Child(name, age);
            Console.WriteLine(child);
        }
    }
}
