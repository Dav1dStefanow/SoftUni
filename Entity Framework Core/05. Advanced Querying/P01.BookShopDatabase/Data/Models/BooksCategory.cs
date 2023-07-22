using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.BookShopDatabase.Data.Models
{
    public class BooksCategory
    {
        public int CategoryId { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public Category Category { get; set; }
    }
}
