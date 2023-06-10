using System;

namespace P01.ClassBoxData
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Box box = new Box(double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()));
            Console.WriteLine($"Lateral surface area - {box.LateralSurfaceArea():F2}");
            Console.WriteLine($"Volume - {box.Volume():F2}");
            Console.WriteLine($"Surface area - {box.SurfaceArea():F2}");
        }
    }
}