using P03.PlayersAndMonsters.Heroes.Knights;
using System;

namespace P03.PlayersAndMonsters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DarkKnight dK = new DarkKnight(Console.ReadLine(),int.Parse(Console.ReadLine()));
            Console.WriteLine(dK);
        }
    }
}
