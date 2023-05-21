using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace P05.GenericCountMethodStrings
{
    internal class StringComparison
    {
        public static int LargerElements<T>(List<T> list, T element)
            where T : IComparable
        {
            int counter = 0;
            foreach(var t in list)
            {
               if(t.CompareTo(element) > 0) counter++;
            }
            return counter;
        }
    }
}
