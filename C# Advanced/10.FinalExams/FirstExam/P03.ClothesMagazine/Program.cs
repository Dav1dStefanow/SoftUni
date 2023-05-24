using System;

namespace P03.ClothesMagazine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Magazine magazine = new Magazine("Zara", 20);
            
            Cloth cloth1 = new Cloth("red", 36, "dress");
            
            Console.WriteLine(cloth1);

            magazine.AddCloth(cloth1);

            Console.WriteLine(magazine.RemoveCloth("black"));
            Cloth cloth2 = new Cloth("brown", 34, "t-shirt");
            Cloth cloth3 = new Cloth("blue", 32, "jeans");

            magazine.AddCloth(cloth2);
            magazine.AddCloth(cloth3);

            Cloth smallestCloth = magazine.GetSmallestCloth();
            Console.WriteLine(smallestCloth);

            Cloth getCloth = magazine.GetCloth("brown");
            Console.WriteLine(getCloth);
            magazine.Report();

        }
    }
}
