using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.DefineAnInterfaceIPerson
{
    public interface IPerson
    {
        string Name { get; set; }
        int Age { get; set; }
    }
}
