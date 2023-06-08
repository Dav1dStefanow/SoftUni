using P06.Animals.Cats;
using P06.Animals.Dogs;
using P06.Animals.Frogs;
using System;

namespace P06.Animals
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            while((input = Console.ReadLine()) != "Beast!")
            {
                string[] animalData = Console.ReadLine().Split();
                string name = animalData[0];
                int age = int.Parse(animalData[1]);
                string gender = animalData[2];
                switch(input)
                {
                    case "Cat":
                        Cat cat = new Cat(name, age, gender);
                        Console.WriteLine(cat);
                        break;
                    case "Dog":
                        Dog dog = new Dog(name, age, gender);
                        Console.WriteLine(dog);
                        break;
                    case "Frog":
                        Frog frog = new Frog(name, age, gender);
                        Console.WriteLine(frog);
                        break;
                    case "Kitten":
                        Kitten kitten = new Kitten(name, age, gender);
                        Console.WriteLine(kitten);
                        break;
                    case "Tomcat":
                        Tomcat tomcat = new Tomcat(name, age, gender);
                        Console.WriteLine(tomcat);
                        break;
                }
            }
        }
    }
}
