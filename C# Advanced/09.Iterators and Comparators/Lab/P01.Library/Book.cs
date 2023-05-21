using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.Library
{
    public class Book : IComparable<Book>
    {
        public Book(string title, int year,List<string> authors) 
        { 
            Title = title;
            Year = year;
            Authors = authors;
        }
        private string title;
        private int year;
        private List<string> authors;

        public string Title
        { 
            get { return this.title; }
            set { this.title = value; }
        }
        public int Year
        { 
            get { return this.year; } 
            set { this.year = value; }
        }
        public List<string> Authors
        { 
            get { return this.authors; }
            set { this.authors = value; }
        }

        public int CompareTo(Book other)
        {
            if (Year < other.Year)
            {
                return -1;
            }
            else if (Year > other.Year)
            {
                return 1;
            }
            else
            {
               return Year.CompareTo(other.Year);

            }
        }
    }
}
