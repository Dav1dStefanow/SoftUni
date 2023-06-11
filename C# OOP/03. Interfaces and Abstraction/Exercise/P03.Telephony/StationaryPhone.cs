using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03.Telephony
{
    internal class StationaryPhone : ICalling
    {
        public void Calling(string number)
        {
            if (number.Length == 10 )
            {
                Console.WriteLine($"Calling... {number}");
            }
            else
            {
                Console.WriteLine($"Dialing... {number}");
            }
        }
    }
}
