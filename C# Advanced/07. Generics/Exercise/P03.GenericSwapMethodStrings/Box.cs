using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03.GenericSwapMethodStrings
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
            for (int i = 0; i < items.Count; i++)
            {
                output.AppendLine($"{typeof(T)}: {items[i]}");
            }
            return output.ToString().Trim();

        }
        public T Swap(int index1,int index2)
        {
            T firstIndexValue = items[index1];
            items[index1] = items[index2];
            items[index2] = firstIndexValue;
            return firstIndexValue;
        }

    }
}
