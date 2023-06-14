using System;

namespace P03.Shapes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Shape circle = new Circle(5.6);
            Shape rectangle = new Rectangle(4.5, 6.7);
            Console.WriteLine(circle.Draw());
            Console.WriteLine(rectangle.Draw());
        }
    }
}
