using System;

namespace P07.Tuple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input1 = Console.ReadLine().Split();
            string[] input2 = Console.ReadLine().Split();
            string[] input3 = Console.ReadLine().Split();

            MyTuple<string, string> strings = new MyTuple<string, string>(input1[0] + " " + input1[1], input1[2]);
            MyTuple<string, int> stringAndInt = new MyTuple<string, int>(input2[0], int.Parse(input2[1]));
            MyTuple<double, double> nums = new MyTuple<double, double>(double.Parse(input3[0]), double.Parse(input3[1]));

            Console.WriteLine(strings);
            Console.WriteLine(stringAndInt);
            Console.WriteLine(nums);
        }
    }
}
