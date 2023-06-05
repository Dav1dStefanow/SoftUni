using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03.ShoeStore
{
    internal class ShoeStore
    {
        public ShoeStore(string name, int storageCApacity)
        {
            Name = name;
            StorageCapacity = storageCApacity;
            Shoes = new List<Shoe>();
        }

        private string name;
        private int storageCapacity;
        private List<Shoe> shoes;

        public string Name
        { 
            get { return name; } 
            set { name = value; }
        }
        public int StorageCapacity
        {
            get { return storageCapacity; }
            set { storageCapacity = value; }
        }
        public List<Shoe> Shoes 
        { 
            get { return shoes; }
            set { shoes = value; }
        }
        public int Count()
        {
            return shoes.Count;
        }
        public void AddShoe(Shoe shoe)
        {
            if(shoes.Count < storageCapacity)
            {
                shoes.Add(shoe);
                Console.WriteLine($"Successfully added {shoe.Type} {shoe.Material} pair of shoes to the store.");
            }
            else
            {
                Console.WriteLine("No more space in the storage room.");
            }
        }
        public int RemoveShoes(string material)
        {
            int removedShoes = 0;
            Stack<Shoe> store = new Stack<Shoe>();
            foreach(Shoe shoe in shoes)
            {
                if(shoe.Material == material)
                {
                    store.Push(shoe);
                    removedShoes++;
                }
            }
            while(store.Count > 0)
            {
                shoes.Remove(store.Pop());
            }
            return removedShoes;
        }
        public List<Shoe> GetShoesByType(string type)
        {
            string typer = type.ToLower();
            foreach(Shoe shoe in shoes)
            {
                if(shoe.Type == typer)
                {
                    Console.WriteLine(shoe);
                }
            }
            return shoes;
        }
        public Shoe GetShoeBySize(double size)
        {
            Shoe currShoe = null;
            foreach(Shoe shoe in shoes)
            {
                if(shoe.Size == size)
                {
                    currShoe = shoe;
                    break;
                }
            }
            return currShoe;
        }
        public string StockList(double size, string type)
        {
            StringBuilder sb = new StringBuilder();
            int matches = 0; 
            sb.AppendLine($"Stock list for size {size} - {type} shoes:");
            foreach(Shoe shoe in shoes)
            {
                if(shoe.Size == size && shoe.Type == type)
                {
                    sb.AppendLine(shoe.ToString());
                    matches++;
                }
            }
            string info = sb.ToString();
            if(matches > 0)
            {
                return info;
            }
            else
            {
                return $"No matches found!";
            }
        }
    }
}
