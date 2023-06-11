using System;
using System.Collections;
using System.Collections.Generic;

namespace P03.Telephony
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> numbers = new Queue<string>(Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries));
            Stack<string> sites = new Stack<string>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries));
            ICalling stationaryRh = new StationaryPhone();
            IBrowsing smartPh = new SmartPhone();
            
            while(numbers.Count > 0)
            {
                stationaryRh.Calling(numbers.Dequeue());
            }
            while(sites.Count > 0)
            {
                smartPh.Browsing(sites.Pop());
            }
        }
    }
}
