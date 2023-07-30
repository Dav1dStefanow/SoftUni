using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealerXML.Models
{
    public class Customer
    {
        public Customer() 
        { 
            this.BoughtCars = new HashSet<Sale>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsYoungDriver { get; set; }
        public ICollection<Sale> BoughtCars { get; set; }
    }
}
