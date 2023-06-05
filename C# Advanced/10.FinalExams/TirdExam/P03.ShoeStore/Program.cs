using System;

namespace P03.ShoeStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ShoeStore store = new ShoeStore("SportiveNation", 10);

            var shoeOne = new Shoe("Nike", "running", 42.5, "textile");
            var shoeTwo = new Shoe("Salomon", "hiking", 42, "textile");
            var shoeThree = new Shoe("Reebok", "running", 38, "textile");
            var shoeFour = new Shoe("LaCoste", "casual", 40.5, "leather");
            var shoeFive = new Shoe("Adidas", "casual", 39, "textile");
            var shoeSix = new Shoe("Nike", "hiking", 42.5, "textile");
            var shoeSeven = new Shoe("Adidas", "casual", 42, "leather");
            var shoeEight = new Shoe("AirJordan", "running", 42, "leather");
            var shoeNine = new Shoe("CalninKlein", "casual", 41.5, "leather");
            var shoeTen = new Shoe("Puma", "hiking", 42, "textile");
            var shoeEleven = new Shoe("Skechers", "casual", 42.5, "leather");

            store.AddShoe(shoeOne);
            store.AddShoe(shoeTwo);
            store.AddShoe(shoeThree);
            store.AddShoe(shoeFour);
            store.AddShoe(shoeFive);
           store.AddShoe(shoeSix);
           store.AddShoe(shoeSeven);
           store.AddShoe(shoeEight);
           store.AddShoe(shoeNine);
           store.AddShoe(shoeTen);
           store.AddShoe(shoeEleven);

            store.GetShoesByType("Running");
            store.GetShoesByType("hIKING");

            Console.WriteLine(store.RemoveShoes("leather"));

            var shoeBySize = store.GetShoeBySize(42.5);
            Console.WriteLine(shoeBySize);


            Console.WriteLine(store.StockList(42, "hiking"));
        }
    }
}
