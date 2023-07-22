using P01.BookShopDatabase.Data.Models.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.BookShopDatabase.Data.Models
{
    public class Book
    {
        public Book() { this.Books = new HashSet<BooksCategory>(); }
        [Key]
        public int BookId { get; set; }
        [MaxLength(50)]
        public string Title  { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Copies { get; set; }
        public decimal Price { get; set; }
        public EditionType EditionType { get; set; }
        public AgeRestriction AgeRestriction { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public ICollection<BooksCategory> Books { get; set; }
    }
}
