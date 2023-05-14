using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.LinkedList
{
    internal class LinkedListItem<T>
    {
        public LinkedListItem(T value) 
        {
            Value = value;
        }

        private LinkedListItem<T> next;
        private LinkedListItem<T> previous;
        private T value;

        public LinkedListItem<T> Next
        { 
            get { return next; }
            set { next = value; }
        }
        public LinkedListItem<T> Previous
        {
            get { return previous; }
            set { previous = value; }
        }
        public T Value
        { 
            get { return value; } 
            set { this.value = value; }
        } 
        
    }
}
