using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.ClassBoxData
{
    internal class Box
    {
        public Box(double length,double width,double height) 
        { 
            Length = length;
            Width = width;
            Height = height;
        }
        private double length;
        private double width;
        private double height;
        public double Length
        {
            get { return this.length; }
            private set 
            { 
                if(value <= 0) throw new ArgumentOutOfRangeException("Length cannot be zero or negative.");

                this.length = value; 
            }
        }

        public double Width
        {
            get { return this.width; }
            private set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException("Width cannot be zero or negative.");

                this.width = value;
            }
        }
        public double Height
        {
            get { return this.height; }
            private set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException("Height cannot be zero or negative.");

                this.height = value;
            }
        }
        public double SurfaceArea()
        {
            double sa = (this.Width * this.Height * 2) + (this.Width * this.Length * 2) + (this.Height * this.Length * 2);
            return sa;
        }
        public double LateralSurfaceArea()
        {
            double sa = 2 * this.Length * this.Height + 2 * this.Width * this.Height;
            return sa;
        }
        public double Volume()
        {
            double sa = this.Width * this.Height * this.Length;
            return sa;
        }
    }
}
