using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03.Stack
{
    internal class MyStack<T> : IEnumerable<T>
    {
        public MyStack(params T[] data) 
        { 
            list = new List<T>(data);
        }
        private List<T> list;

        public void Push(params T[] items)
        {
            foreach(T item in items)
            {
                list.Insert(list.Count, item);
            }
        }
        public T Pop()
        {
            if (list.Count == 0) throw new ArgumentException("No Elements");
            T element = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);
            return element;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = list.Count -1; i >= 0; i--)
            {
                yield return list[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
