using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03.Shapes
{
    public class Circle : Shape
    {
        public Circle(double radius)
        { 
            this.radius = radius;
        }
        private double radius;
        public override double CalculateArea()
        {
            return radius * radius;
        }

        public override double CalculatePerimeter()
        {
            return (radius + radius) * 2;
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
