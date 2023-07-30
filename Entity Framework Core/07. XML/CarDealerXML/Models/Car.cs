using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealerXML.Models
{
    public class Car
    {
        public Car() 
        { 
            this.SoldCars = new HashSet<Sale>();
            this.PartCars = new HashSet<PartCar>();

        }
        public int Id { get; set; } 
        public string Make { get; set; }
        public string Model { get; set; }
        public int TraveledDistance { get; set; }
        public ICollection<Sale> SoldCars { get; set;}
        public ICollection<PartCar> PartCars { get; }
    }
}
