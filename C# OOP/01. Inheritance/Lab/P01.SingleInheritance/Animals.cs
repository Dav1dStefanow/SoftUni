using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.SingleInheritance
{
    abstract class Animals
    {
        public void Eating()
        {
            Console.WriteLine("eating...");
        }
    }
    class Dog : Animals
    {
        public void Barking()
        {
            Console.WriteLine("barking...");
        }
    }
}
