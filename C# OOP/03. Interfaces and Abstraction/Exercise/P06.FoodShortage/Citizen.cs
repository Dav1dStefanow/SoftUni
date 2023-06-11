using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06.FoodShortage
{
    public class Citizen : IIdentifiable, IBirthable, IBuyer
    {
        public Citizen(string name, int age, string id, string birthdate) 
        { 
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthday = birthdate;
        }
        public string Name { get; set; }
        public int Age { get; private set; }
        public int Food { get; set; }
        public string Id { get; set; }
        public string Birthday { get; set; }

        public int BuyFood()
        {
            return this.Food += 10;
        }
    }
}
