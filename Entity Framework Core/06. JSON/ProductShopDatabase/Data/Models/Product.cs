using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShopDatabase.Data.Models
{
    public class Product
    {
        public Product()
        {
            this.CategoryProducts = new List<CategoryProduct>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        [InverseProperty(nameof(User.Sellers))]
        public int SellerId { get; set; }
        public User Seller { get; set; }
        [InverseProperty(nameof(User.Buyers))]
        public int? BuyerId { get; set; }
        public User Buyer { get; set; }
        public ICollection<CategoryProduct> CategoryProducts { get; set; }
    }
}
