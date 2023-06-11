using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05.BirthdayCelebrations
{
    public class Pet : IBirthable
    {
        public Pet(string name, string birthdate) 
        { 
            this.Name = name;
            this.BirthDate = birthdate;
        }
        public string Name { get; private set; }
        public string BirthDate { get; set; }
    }
}
