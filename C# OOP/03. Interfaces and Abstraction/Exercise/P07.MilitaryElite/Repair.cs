using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P07.MilitaryElite
{
    public class Repair
    {
        public Repair(string name, int hours) 
        { 
            this.Hours = hours;
            this.Name = name;
        }

        public string Name { get; private set; }
        public int Hours { get; private set; }
    }
}
