using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace P01.ListyIterator
{
    internal class ListyIterator<T>
    {
        public ListyIterator(params T[] data) 
        { 
            items = new List<T>(data);
            currIndex = 0;
        }
        private List<T> items;
        private int currIndex;
        public bool Move()
        {
            bool canMove = HasNext();
            if (canMove) currIndex++;
            return canMove;
        }
        public void Print()
        {
            if(items.Count == 0) throw new ArgumentException("Invalid operation!");
            else Console.WriteLine(items[currIndex]);
        }
        public bool HasNext() => currIndex + 1 < items.Count;
    }
}
