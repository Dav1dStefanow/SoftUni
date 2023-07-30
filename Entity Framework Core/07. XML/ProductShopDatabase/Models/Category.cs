using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShopDatabase.Models
{
    public class Category
    {
        public Category() 
        {
            this.CategoryProducts = new HashSet<CategoryProducts>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<CategoryProducts> CategoryProducts { get; set;}
    }
}
