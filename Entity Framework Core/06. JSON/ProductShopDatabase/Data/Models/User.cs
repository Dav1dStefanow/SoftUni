using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShopDatabase.Data.Models
{
    public class User
    {
        public User() 
        {
            this.Sellers = new HashSet<Product>();
            this.Buyers = new HashSet<Product>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }
        public ICollection<Product> Sellers { get; set; }
        public ICollection<Product> Buyers { get; set; }
    }
}
