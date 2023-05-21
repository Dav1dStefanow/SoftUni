using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace P01.GenericBoxOfString
{
    internal class Box<T>
    {
        
        private List<T> items = new List<T>();
        public int Count() => items.Count;

        public void Add(T value)
        {
            items.Add(value);
        }
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            for(int i = 0;i < items.Count;i++)
            {
                output.AppendLine($"{typeof(T)}: {items[i]}");
            }
            return output.ToString().Trim();

        }
       
    }
}
