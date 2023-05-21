using System;
using System.Collections;
using System.Collections.Generic;

namespace P01.Library
{
    class Library : IEnumerable<Book>
    {
        public Library()
        {
            books = new List<Book>();
        }
        private List<Book> books;
        public void Add(Book book)
        {
            this.books.Add(book);
        }
        public void Remove(Book book)
        {
            this.books.Remove(book);
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}

