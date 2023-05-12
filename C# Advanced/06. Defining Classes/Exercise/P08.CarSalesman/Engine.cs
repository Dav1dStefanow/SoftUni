using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P08.CarSalesman
{
    internal class Engine
    {
        public Engine() 
        { 
        
        }
        
        private string model;
        private int power;
        private string displacement = "n/a";
        private string efficiency = "n/a";

        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public int Power
        { 
            get { return power; } 
            set { power = value; }
        }
        public string Displacement
        {  
            get { return displacement; }
            set { displacement = value; } 
        }
        public string Efficiency
        { 
            get { return efficiency; }
            set { efficiency = value; }
        }
    }
}
