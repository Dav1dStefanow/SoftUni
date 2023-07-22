using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.BookShopDatabase.Data.Models
{
    public class Category
    {
        public Category() { this.Categories = new HashSet<BooksCategory>(); }
        [Key] 
        public int CategoryId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }    
        public ICollection<BooksCategory> Categories { get; set; }
    }
}
