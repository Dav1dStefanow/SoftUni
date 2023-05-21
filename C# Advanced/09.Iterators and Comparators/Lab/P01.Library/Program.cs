using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace P01.Library
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*var library = new List<Book>(); How to sort them by Year */
            var library = new Library();
            library.Add(new Book("Lord Of The Rings", 1954, new List<string>() { "J.Tolkien" }));
            library.Add(new Book("1984", 1949, new List<string>() { "George Orwell" }));
            library.Add(new Book("Harry Potter", 1997, new List<string>() { "J.K.Rowling" }));
            library.Add(new Book("And Then There Were None", 1939, new List<string>() { "Agatha Christie" }));
            library.Sort(); /*How to sort them by Year */

            foreach (var book in library)
            {
                Console.WriteLine($"{book.Title} - {string.Join("&",book.Authors)} ({book.Year})");
            }
        }
    }
}
