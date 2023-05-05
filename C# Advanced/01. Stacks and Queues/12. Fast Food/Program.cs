using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Numerics;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace FastFood
{

    class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());
            int[] ordersAmmount = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> orders = new Queue<int>();
            int biggestOrder = 0;
            foreach (int order in ordersAmmount)
            {
                orders.Enqueue(order);
                if(biggestOrder < order)
                {
                    biggestOrder = order;
                }
            }
            bool areOrdersComplete = true;
            int ordersComplete = 0;
            foreach (int order in orders)
            {
                if(foodQuantity - order < 0)
                {
                    areOrdersComplete = false;
                    break;
                }
                else
                { 
                    foodQuantity -= order;
                    ordersComplete++;
                }
            }
            if(areOrdersComplete )
            {
                Console.WriteLine(biggestOrder);
                Console.WriteLine("Orders complete");
            }
            else
            {
                for (int i = 0; i < ordersComplete; i++)
                {
                    orders.Dequeue();
                }
                Console.WriteLine(biggestOrder);
                Console.Write($"Orders left: " + string.Join(" ",orders));  
            }
        }
    }
}