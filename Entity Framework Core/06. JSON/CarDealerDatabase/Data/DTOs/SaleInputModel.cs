using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealerDatabase.Data.DTOs
{
    public class SaleInputModel
    {
        public int Discount { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
    }
}
