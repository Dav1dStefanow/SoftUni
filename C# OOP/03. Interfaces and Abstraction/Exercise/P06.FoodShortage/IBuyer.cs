using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06.FoodShortage
{
    public interface IBuyer
    {
        string Name { get; set; }
        int Food { get; set; }
        int BuyFood();
    }
}
