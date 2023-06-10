using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01._Shapes
{
    internal class Circle : IDrawable
    {
        public Circle(int radius) 
        { 
            this.Radius = radius;
        }
        private int radius;

        public int Radius
        {
            get { return radius; }
            private set { radius = value; }
        }

        public void Draw()
        {
            double reIn = this.radius - 0.4;
            double reOut= this.radius + 0.4;
            for (double y = this.radius; y >= -this.radius; y--)
            {
                for (double x = -this.radius; x < reOut; x += 0.5)
                {
                    double value = x * x + y * y;
                    if(value >= reIn * reIn &&  value <= reOut * reOut)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }

        }
    }
}
