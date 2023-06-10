using System;
using System.Collections.Generic;

namespace P04.PizzaCalories
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] pizzaInfo = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
            string[] doughInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Pizza pizza = new Pizza(pizzaInfo[1],new Dough(doughInfo[1], doughInfo[2],int.Parse(doughInfo[3])));

            string[] toppingInfo = Console.ReadLine().Split();
            while (toppingInfo[0] != "END")
            {
                Topping topping = new Topping(toppingInfo[1], int.Parse(toppingInfo[2]));
                pizza.AddTopping(topping);

                toppingInfo = Console.ReadLine().Split();
            }

            pizza.TotalCalories();
        }
    }
}
