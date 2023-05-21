using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02.GenericArrayCreator
{
    internal class Creator
    {
        public static T[] Create<T>(int times,T value)
        {
            T[] arr = new T[times];
            for(int i = 0;i < times;i++)
            {
                arr[i] = value;
            }
            return arr;
        }
    }
}
