using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P07.MilitaryElite
{
    public class SpecialisedSoldier
    {
        public SpecialisedSoldier(string corps) 
        { 
            this.Corps = corps;
        }
        protected string corps;
        public string Corps 
        {
            get { return this.corps; }
            set { this.corps = value; }
        }
    }
}
