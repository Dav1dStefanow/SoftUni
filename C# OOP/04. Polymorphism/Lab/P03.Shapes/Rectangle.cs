using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03.Shapes
{
    public class Rectangle : Shape
    {
        public Rectangle(double height, double width) 
        { 
            this.height = height;
            this.width = width;
        }
        private double height;
        private double width;
        public override double CalculateArea()
        {
            return (height + width) * 2;
        }

        public override double CalculatePerimeter()
        {
            return height * width;
        }
        public override string Draw()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Drawing {GetType().Name}");
            sb.AppendLine($"{CalculatePerimeter():F2}");
            sb.AppendLine($"{CalculateArea():F2}");
            return sb.ToString();
        }
    }
}
