using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace P03.Telephony
{
    internal class SmartPhone : ICalling, IBrowsing
    {
        public void Browsing(string site)
        {
            if(Regex.IsMatch(site, "[htp]{4}[:][\\/]{2}[a-zA-Z]+[.][a-z]{2,}"))
            {
                Console.WriteLine($"Browsing: {site}");
            }
            else 
            {
                Console.WriteLine("Invalid URL!");
            }
        }

        public void Calling(string number)
        {
            if (Regex.IsMatch(number, "[0-9]{10}"))
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
