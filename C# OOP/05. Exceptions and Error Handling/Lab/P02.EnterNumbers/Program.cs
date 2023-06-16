using System;
using System.Collections.Generic;

namespace P02.EnterNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            ReadNumbers(a, b);



            void ReadNumbers(int a, int b)
            {
                List<int> nums = new List<int>();

                for(int i = 0; i < 10; i++)
                {
                    while(true)
                    {
                        try
                        {
                            int n = int.Parse(Console.ReadLine());
                            if (n < 1 || n > 100)
                            {
                                throw new ArgumentOutOfRangeException();
                            }
                            else
                            {
                                nums.Add(n);
                                break;
                            }
                        }
                        catch (ArgumentOutOfRangeException)
                        {

                            Console.WriteLine("Number is not in range (1 - 100)");
                        }
                        catch(Exception)
                        {
                            Console.WriteLine("Invalid Number!");
                        }
                    }
                }
                Console.WriteLine(string.Join(", ",nums));
            }
        }
    }
}

