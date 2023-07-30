using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProductShopDatabase.DTOs
{
    [XmlType("CategoryProduct")]
    public class CategoryProductsInputModel
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
    }
}
