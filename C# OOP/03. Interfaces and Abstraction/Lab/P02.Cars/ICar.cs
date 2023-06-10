using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02.Cars
{
    internal interface ICar
    {
        string Model { get; protected set; }
        string Color { get; protected set; }
        public virtual string Start()
        {
            return "";
        }
        public virtual string Stop()
        {
            return "";
        }
    }
}
