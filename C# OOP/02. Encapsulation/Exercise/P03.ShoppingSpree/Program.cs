using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.ShoppingSpree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,Person> people = new Dictionary<string, Person>();
            Dictionary<string, Product> products = new Dictionary<string, Product>();

            string[] personInfos = Console.ReadLine().Split(';',StringSplitOptions.RemoveEmptyEntries);
            string[] productInfos = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

            foreach(string personInfo in personInfos) 
            {
                string[] strings = personInfo.Split('=');
                string name = strings[0]; decimal money = decimal.Parse(strings[1]);
                people.Add(name, new Person(name, money));
            }
            foreach (string productInfo in productInfos)
            {
                string[] strings = productInfo.Split('=');
                string name = strings[0]; decimal price = decimal.Parse(strings[1]);
                products.Add(name, new Product(name, price));
            }
            string[] input = Console.ReadLine().Split();
            while(input[0] != "END")
            {
                string currPersonName = input[0];
                string currProductName = input[1];
                people[currPersonName].BuyProduct(products[currProductName]);

                input = Console.ReadLine().Split();
            }
            foreach (var person in people)
            {
                if (person.Value.BagOfProducts.Count > 0) Console.WriteLine($"{person.Value.Name} - {string.Join(", ", person.Value.BagOfProducts.Select(x => x.Name))}");
                else Console.WriteLine($"{person.Value.Name} - Nothing bought");
            }
        }
    }
}
