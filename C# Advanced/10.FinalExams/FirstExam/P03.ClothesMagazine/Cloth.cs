using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03.ClothesMagazine
{
    internal class Cloth
    {
        public Cloth(string color, int size, string type) 
        { Color = color;Size = size; Type = type; }

        private string color;
        private int size;
        private string type;

        public string Color
        {
            get { return color; }
            set { color = value; }
        }
        public int Size
        {
            get { return size; }
            set { size = value; }
        }
        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public override string ToString()
        {
            return $"Product: {Type} with size {Size}, color {Color}";
        }
    }
}
