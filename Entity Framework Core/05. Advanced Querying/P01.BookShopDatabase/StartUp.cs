using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Primitives;
using P01.BookShopDatabase.Data;
using P01.BookShopDatabase.Data.Models;
using P01.BookShopDatabase.Data.Models.Enumerations;
using P01.BookShopDatabase.Generators;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace P01.BookShopDatabase
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            var db = new BookShopContext();
            Console.WriteLine(RemoveBooks(db));
        }
        // problem 16
        public static int RemoveBooks(BookShopContext db)
        {
            var query = db.Books
               .Where(y => y.Copies < 4200);
            int count = 0;
            foreach (var item in query)
            {
                db.Remove(item); 
                count++;
            }
            return count;
        }
        // problem 15
        public static void IncreasePrices(BookShopContext db)
        {
            var query = db.Books
                .Where(y => y.ReleaseDate.Year < 2010);
            foreach (var book in query)
            {
                book.Price += 5;
            }
            db.SaveChanges();
        }
        // problem 14
        public static string GetMostRecentBooks(BookShopContext db)
        {
            StringBuilder sb = new StringBuilder();

            var query = db.Categories
                .OrderBy(c => c.Name)
                .Select(c => new
                {
                    c.Name
                    ,
                    BookList = c.Categories
                    .Select(b => new
                    {
                        b.Book.Title
                        ,
                        Year = b.Book.ReleaseDate.Year
                    })
                    .OrderByDescending(n => n.Year).Take(3).ToList()
                }).ToList()
                .OrderBy(c => c.Name)
                .ToList();
            foreach (var c in query)
            {
                sb.AppendLine($"--{c.Name}");
                foreach (var b in c.BookList)
                {
                    sb.AppendLine($"{b.Title} ({b.Year})");
                }
            }
            return sb.ToString().TrimEnd();
        }
        // problem 13
        public static string GetTotalProfitByCategory(BookShopContext db)
        {
            StringBuilder sb = new StringBuilder();
            var query = db.Categories
                .Select(x => new
                {
                    x.Name
                    ,
                    TotalProfit = x.Categories
                    .Select(x => new
                    {
                        BookProfit = x.Book.Price * x.Book.Copies
                    }).Sum(x => x.BookProfit)
                })
                .OrderByDescending(c => c.TotalProfit)
                .ThenBy(x => x.Name)
                .ToList();
            foreach (var b in query)
            {
                sb.AppendLine($"{b.Name} ${b.TotalProfit}");
            }
            return sb.ToString();
        }
        // problem 12
        public static string CountCopiesByAuthor(BookShopContext db)
        {
            StringBuilder sb = new StringBuilder();
            var query = db.Books
                .OrderByDescending(x => x.Copies)
                .Select(x => new { x.Copies, Name = x.Author.FirstName + " " + x.Author.LastName })
                .ToList();
            foreach (var book in query)
            {
                sb.AppendLine($"{book.Name} - {book.Copies}");
            }
            return sb.ToString();
        }
        // problem 11
        public static int CountBooks(BookShopContext db, int lengthCheck)
        {
            var query = db.Books
                .Where(t => t.Title.Length > lengthCheck)
                .Count();
            return query;
        }
        // problem 10
        public static string GetBooksByAuthor(BookShopContext db, string input)
        {
            StringBuilder sb = new StringBuilder();
            var query = db.Books
                .Where(t => t.Author.LastName.StartsWith(input))
                .OrderBy(t => t.BookId)
                .Select(t => new { t.Title, AName = t.Author.FirstName + " " + t.Author.LastName })
                .ToList();
            foreach (var book in query)
            {
                sb.AppendLine($"{book.Title} ({book.AName})");
            }
            return sb.ToString();
        }
        // problem 9
        public static string GetBookTitlesContaining(BookShopContext db, string input)
        {
            var query = db.Books
                .Where(t => t.Title.Contains(input))
                .Select(t => t.Title)
                .OrderBy(t => t)
                .ToList();
            return String.Join(Environment.NewLine, query);
        }
        // problem 8
        public static string GetAuthorNamesEndingIn(BookShopContext db, string ends)
        {

            var query = db.Authors
                .Where(n => n.FirstName.EndsWith(ends))
                .Select(n => n.FirstName + " " + n.LastName)
                .Distinct()
                .OrderBy(f => f)
                .ToList();

            return String.Join(Environment.NewLine, query);
        }
        // problem 7
        public static string GetBooksReleasedBefore(BookShopContext db, string date)
        {
            StringBuilder sb = new StringBuilder();
            DateTime dateTime = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            var query = db.Books
                .Where(p => p.ReleaseDate < dateTime)
                .OrderByDescending(p => p.ReleaseDate)
                .Select(p => new
                {
                    p.Title
                    ,
                    p.EditionType
                    ,
                    p.Price
                })
                .ToList();
            foreach (var item in query)
            {
                sb.AppendLine($"{item.Title} - {item.EditionType} - ${item.Price}");
            }
            return sb.ToString();
        }
        // problem 6
        public static string GetBooksByCategory(BookShopContext db, string listCategories)
        {
            List<string> categories = listCategories.ToLower().Split().ToList();

            var query = db.Books
                .Where(b => b.Books.Any(b => categories.Contains(b.Category.Name.ToLower())))
                .Select(b => b.Title)
                .OrderBy(t => t)
                .ToList();

            return String.Join(Environment.NewLine, query);
        }
        //problem 5
        public static string GetBooksNotReleasedIn(BookShopContext db, int year)
        {
            var books = db.Books
               .Where(p => p.ReleaseDate.Year != year)
               .OrderBy(p => p.BookId)
               .Select(b => b.Title)
               .ToList();

            return String.Join(Environment.NewLine, books);
        }
        // problem 4
        public static string GetBooksByPrice(BookShopContext db)
        {
            StringBuilder sb = new StringBuilder();
            var books = db.Books
                .Where(p => p.Price > 40)
                .Select(b => new { b.Title, b.Price })
                .OrderByDescending(b => b.Price)
                .ToList();
            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price}");
            }
            return sb.ToString();
        }
        // problem 3
        public static string GetGoldenBooks(BookShopContext db)
        {
            var books = db.Books
                .Where(b => b.Copies < 5000 && b.EditionType == EditionType.gold)
                .OrderBy(i => i.BookId)
                .Select(p => p.Title)
                .ToList();

            return String.Join(Environment.NewLine, books);
        }
        // problem 2
        public static string GetBooksByAgeRestriction(BookShopContext db, string restriction)
        {
            StringBuilder sb = new StringBuilder();
            var ageRestriction = Enum.Parse(typeof(AgeRestriction), restriction.ToLower(), true);
            var query = db.Books
                .Where(a => a.AgeRestriction.Equals(ageRestriction))
                .Select(b => new { b.Title })
                .OrderBy(t => t.Title)
                .ToList();
            foreach (var book in query)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().Trim();
        }
        // problem 1
        public static void AddData(BookShopContext db)
        {
            Category[] categories = CategoryGenerator.CreateCategories();
            Book[] boks = BookGenerator.CreateBooks();
            Author[] authors = AuthorGenerator.CreateAuthors();
            for (int i = 0; i < boks.Length; i++)
            {
                db.Books.Add(boks[i]);
            }
            for (int i = 0; i < authors.Length; i++)
            {
                db.Authors.Add(authors[i]);
            }
            for (int i = 0; i < categories.Length; i++)
            {
                db.Categories.Add(categories[i]);
            }
            db.SaveChanges();
        }
    }
}
