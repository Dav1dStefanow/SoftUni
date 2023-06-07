using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05.StackOfStrings
{
    internal class StackOfString : Stack<string>
    {
        public bool IsEmpty()
        {
            if(Count == 0) return true;
            return false;
        }
        public void AddRange(IEnumerable<string> items)
        {
            foreach(var item in items)
            {
                Push(item);
            }
        }
    }
}
