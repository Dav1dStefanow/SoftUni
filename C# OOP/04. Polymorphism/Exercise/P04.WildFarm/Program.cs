using P04.WildFarm.Animals;
using P04.WildFarm.Foods;
using System;
using System.Collections.Generic;
using System.Security;

namespace P04.WildFarm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<Animal> animals = new Stack<Animal>();
            string input;
            while((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split(' ',StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0] == "Cat")
                {
                    Animal cat = new Cat(tokens[1], double.Parse(tokens[2]), tokens[3], tokens[4]);
                    animals.Push(cat);
                }
                else if (tokens[0] == "Dog")
                {
                    Animal dog = new Dog(tokens[1], double.Parse(tokens[2]), tokens[3]);
                    animals.Push(dog);
                }
                else if (tokens[0] == "Owl")
                {
                    Animal owl = new Owl(tokens[1], double.Parse(tokens[2]), double.Parse(tokens[3]));
                    animals.Push(owl);
                }
                else if (tokens[0] == "Hen")
                {
                    Animal hen = new Hen(tokens[1], double.Parse(tokens[2]), double.Parse(tokens[3]));
                    animals.Push(hen);
                }
                else if (tokens[0] == "Tiger")
                {
                    Animal tiger = new Tiger(tokens[1], double.Parse(tokens[2]), tokens[3], tokens[4]);
                    animals.Push(tiger);
                }
                else if (tokens[0] == "Mouse")
                {
                    Animal mouse = new Mouse(tokens[1], double.Parse(tokens[2]), tokens[3]);
                    animals.Push(mouse);
                }
                else if (tokens[0] == "Vegetable")
                {
                    Vegetable vegy = new Vegetable(int.Parse(tokens[1]));
                    Animal ani = animals.Peek();
                    ani.GiveFood(vegy);
                }
                else if (tokens[0] == "Fruit")
                {
                    Fruit fruty = new Fruit(int.Parse(tokens[1]));
                    Animal ani = animals.Peek();
                    ani.GiveFood(fruty);
                }
                else if (tokens[0] == "Seed")
                {
                    Seed seed = new Seed(int.Parse(tokens[1]));
                    Animal ani = animals.Peek();
                    ani.GiveFood(seed);
                }
                else if (tokens[0] == "Meat")
                {
                    Meat meat = new Meat(int.Parse(tokens[1]));
                    Animal ani = animals.Peek();
                    ani.GiveFood(meat);
                }
            }
            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
