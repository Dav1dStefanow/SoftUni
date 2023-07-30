using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShopDatabase.Models
{
    public class Product
    {
        public Product() 
        { 
            this.CategoryProducts = new HashSet<CategoryProducts>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int SellerId { get; set; }
        public User Seller { get; set; }
        public int? BuyerId { get; set; }
        public User Buyer { get; set; }
        public ICollection<CategoryProducts> CategoryProducts { get; set; }
    }
}
