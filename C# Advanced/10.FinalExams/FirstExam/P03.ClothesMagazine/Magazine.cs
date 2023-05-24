using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03.ClothesMagazine
{
    internal class Magazine
    {
        public Magazine(string type, int capacity)
        { Type = type; Capacity = capacity; Clothes = new List<Cloth>(); }

        private string type;
        private int capacity;
        private List<Cloth> clothes;

        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }
        public List<Cloth> Clothes
        {
            get { return clothes; }
            set { clothes = value; }
        }
        public void AddCloth(Cloth cloth)
        {
            if (capacity > clothes.Count) clothes.Add(cloth);
        }
        public bool RemoveCloth(string color)
        {
            foreach (var cloth in clothes)
            {
                if (cloth.Color == color)
                {
                    clothes.Remove(cloth);
                    return true;
                }
            }
            return false;
        }
        public Cloth GetSmallestCloth() 
        {
            int smallestSize = int.MaxValue;
            Cloth wantedCloth = null;
            foreach(var cloth in clothes)
            {
                if(cloth.Size < smallestSize)
                {
                    smallestSize = cloth.Size;
                }
            }
            foreach(var cloth in clothes)
            {
                if(cloth.Size == smallestSize)
                {
                    wantedCloth = cloth;
                }
            }
            return wantedCloth;
        }
        public Cloth GetCloth(string color) 
        { 
            Cloth cloth1 = null;
            foreach (var cloth in clothes)
            {
                if(cloth.Color == color)
                {
                    cloth1 = cloth;
                }
            }
            return cloth1;
        }
        public int GetClothCount()
        {
            return clothes.Count;
        }
        public void Report()
        {

            Console.WriteLine($"{Type} magazine contains:");
            foreach(Cloth cloth in clothes)
            {
                Console.WriteLine(cloth);
            }
        }
    }
}

