using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShopDatabase.Models
{
    public class User
    {
        public User() 
        {
            this.Sales = new HashSet<Product>();
            this.ProductsSold = new HashSet<Product>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }
        public ICollection<Product> Sales { get; set; }
        public ICollection<Product> ProductsSold { get; set; }
    }
}
