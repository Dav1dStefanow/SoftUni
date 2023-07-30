using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealerXML.Models
{
    public class Part
    {
        public Part() 
        { 
            this.CarParts = new HashSet<PartCar>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public ICollection<PartCar> CarParts { get; set; }
    }
}
