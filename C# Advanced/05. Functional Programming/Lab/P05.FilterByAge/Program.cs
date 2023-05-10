using System;
using System.Collections.Generic;

namespace P05.FilterByAge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> people = new Dictionary<string, int>();
            int personsCount = int.Parse(Console.ReadLine());
            for(int i = 0; i < personsCount; i++)
            {
                string[] input = Console.ReadLine().Split(", ");
                string name = input[0];
                int age = int.Parse(input[1]);
                people[name] = age;
            }
            string youngerOlder = Console.ReadLine();
            int ageFactor = int.Parse(Console.ReadLine());
            string[] command = Console.ReadLine().Split();
            foreach(var guy in people) 
            {
                if(youngerOlder == "younger")
                {
                    if(guy.Value <= ageFactor)
                    {
                        if(command.Length == 2)
                        {
                            Console.WriteLine($"{guy.Key} - {guy.Value}");
                        }
                        else
                        {
                            if (command[0] == "name")
                            {
                                Console.WriteLine($"{guy.Key}");
                            }
                            else
                            {
                                Console.WriteLine($"{guy.Value}");
                            }
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (youngerOlder == "older")
                {
                    if (guy.Value >= ageFactor)
                    {
                        if (command.Length == 2)
                        {
                            Console.WriteLine($"{guy.Key} - {guy.Value}");
                        }
                        else
                        {
                            if (command[0] == "name")
                            {
                                Console.WriteLine($"{guy.Key}");
                            }
                            else
                            {
                                Console.WriteLine($"{guy.Value}");
                            }
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }
    }
}
