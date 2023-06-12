using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P07.MilitaryElite
{
    public class Mission
    {
        public Mission(string codeName, string state) 
        {
            this.CodeName = codeName;
            this.State = state;
        }

        private string codename;
        private string state;
        public string CodeName 
        {
            get { return this.codename; }
            private  set { this.codename = value; }
        }
        public string State 
        {
            get { return this.state; }
            set { this.state = value; }
        }
       
    }
}
