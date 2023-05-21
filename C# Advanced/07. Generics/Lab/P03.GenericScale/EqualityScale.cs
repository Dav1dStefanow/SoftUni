using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03.GenericScale
{
    internal class EqualityScale
    {
        public static bool AreEqual<T>(T left,T right)
        {
            return left.Equals(right);
        }
    }
}
