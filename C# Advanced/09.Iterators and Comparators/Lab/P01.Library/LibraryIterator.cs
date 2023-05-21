﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.Library
{
    public class LibraryIterator : IEnumerator<Book>
    {
        private List<Book> books;
        private int index;
        public LibraryIterator(List<Book> books) 
        { 
            this.books = books;
            this.index = -1;
        }
        public Book Current => books[index];

        object IEnumerator.Current => Current;

        public void Dispose()
        {
           
        }

        public bool MoveNext()
        {
            index++;
            return index < books.Count;
        }

        public void Reset()
        {
            index = -1;
        }
    }
}
