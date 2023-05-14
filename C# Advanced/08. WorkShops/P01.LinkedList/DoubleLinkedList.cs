using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.LinkedList
{
    internal class DoubleLinkedList<T>
    {
        private LinkedListItem<T> first = null;
        private LinkedListItem<T> last = null;

        public int Count 
        {
            get 
            { 
                int count = 0;
                LinkedListItem<T> current = first;
                while(current != null)
                {
                    current = current.Next;
                    count++;
                }
                return count;
                /* return GetCount(first);*/
            }
        }
        //Get the count with recursion
        /*int GetCount(LinkedListItem current)
        {
            if (current != null)
            {
                return 0;
            }

            return 1 + GetCount(current.Next);
        }*/
        public void AddFirst(T element)
        {
            LinkedListItem<T> newItem = new LinkedListItem<T>(element);
            if (first == null)
            {
              this.first = newItem;
              this.last = newItem;
            }
            else
            {
                newItem.Next = first;
                first.Previous = newItem;
                first = newItem;
            }
        }
        public void AddLast(T element)
        {
            LinkedListItem<T> newItem = new LinkedListItem<T>(element);
            if (last == null)
            {
               this.first = newItem;
               this.last = newItem;
            }
            else
            {
                newItem.Previous = last;
                last.Next = newItem;
                last = newItem;
            }
        }
        public T RemoveFirst()
        {
            if (first == null)
            {
                throw new InvalidOperationException("Linked List is empty!");
            }
            T curFirstValue = first.Value;
            if(first == last)
            {
                this.first = null;
                this.last = null;
            }
            else
            {
                var newFirst = first.Next;
                newFirst.Previous = null;
                first = newFirst;
            }
            return curFirstValue;
        }

        public T RemoveLast()
        {
            if (first == null)
            {
                throw new InvalidOperationException("Linked List is empty!");
            }
            T curLastValue = last.Value;
            if (first == last)
            {
                this.first = null;
                this.last = null;
            }
            else
            {
                var newLast = last.Previous;
                newLast.Next = null;
                last = newLast;
            }
            return curLastValue;
        }
        public T[] ToArray()
        {
            T[] array = new T[Count];
            var current = first; 
            for(int i = 0; i < Count;i++)
            {
                array[i] = current.Value;
                current = current.Next;
            }
            return array;
        }
        public void ForEach(Action<T> action)
        {
            var current = first;
            while (current != null)
            {
                action(current.Value);
                current = current.Next;
            }
        }
    }
}
