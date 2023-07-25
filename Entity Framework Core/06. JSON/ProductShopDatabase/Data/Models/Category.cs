using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShopDatabase.Data.Models
{
    public class Category
    {
        public Category() 
        {
            this.CategoryProducts = new List<CategoryProduct>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<CategoryProduct> CategoryProducts { get; set; }
    }
}
