using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04.NeedForSpeed.Vehicles.Motorcycles
{
    internal class CrossMotorcycle : Motorcycle
    {
        public CrossMotorcycle(int horsePower, double fuel)
            : base(horsePower, fuel)
        {
            HorsePower = horsePower;
            Fuel = fuel;
        }
    }
}
