using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealerDatabase.Data.Models
{
    public class Customer
    {
        public Customer() 
        {
            this.Buyers = new HashSet<Sale>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsYoungDriver { get; set; }
        public virtual ICollection<Sale> Buyers { get; set; }
    }
}
