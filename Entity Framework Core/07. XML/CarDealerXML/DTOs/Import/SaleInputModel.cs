using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CarDealerXML.DTOs.Import
{
    [XmlType("Sale")]
    public class SaleInputModel
    {
        [XmlElement("discount")]
        public int Discount { get; set; }
        [XmlElement("carId")]
        public int CarId { get; set; }
        [XmlElement("customerId")]
        public int CustomerId { get; set; }
    }
}
