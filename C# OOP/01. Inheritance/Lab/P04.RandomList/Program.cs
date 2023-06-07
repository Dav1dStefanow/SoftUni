using System;

namespace P04.RandomList
{
    internal class Program
    {
        static void Main(string[] args)
        {
           RandomList list = new RandomList();
            list.Add("1");
            list.Add("2");
            list.Add("3");
            list.Add("4");
            list.Add("5");
            list.Add("6");
            list.Add("12");
            for(int i = 0; i < 10; i++)
            {
                Console.Write(list.GetRandomElement() + " ");
            }
            Console.WriteLine();
            list.RemoveRandomElement();
            Console.WriteLine(string.Join(" ",list));
        }
    }
}
