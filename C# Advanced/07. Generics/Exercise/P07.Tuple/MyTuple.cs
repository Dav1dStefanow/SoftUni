using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P07.Tuple
{
    internal class MyTuple<T1,T2>
    {
        public MyTuple(T1 a, T2 b) 
        {
            A = a;
            B = b;
        }
        private T1 a;
        private T2 b;
        public T1 A 
        { 
            get { return a; }
            set { a = value; }
        }
        public T2 B 
        { 
            get { return b;}
            set { b = value; }
        }
        public override string ToString()
        {
            return $"{A} -> {B}";
        }
    }
}
