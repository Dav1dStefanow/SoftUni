using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.Box
{
    internal class Box<T>
    {
       
        private List<T> list = new List<T>();
        public int Count 
        {
            get
            {
                return list.Count;
            }
        }

        public void Add(T item)
        {
            list.Add(item);

        }
        public T Remove()
        {
            var element = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);
            return element;
        }
        public T[] ToArray()
        {
            var array = new T[list.Count];
            for(int i = 0; i < list.Count;i++)
            {
                array[i] = list[i];
            }
            return array;
        }
    }
}
