using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealerDatabase.Data.Models
{
    public class Car
    {
        public Car()
        {
            this.ChosenCars = new HashSet<Sale>();  
            this.CarParts = new HashSet<PartCar>();
        }
        public int Id { get; set; } 
        public string Make { get; set; }
        public string Model { get; set; }
        public int TraveledDistance { get; set; }
        public virtual ICollection<Sale> ChosenCars { get; set;}
        public virtual ICollection<PartCar> CarParts { get; set; }
    }
}
