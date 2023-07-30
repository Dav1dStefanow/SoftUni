using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CarDealerXML.DTOs.Export
{
    [XmlType("sale")]
    public class SaleExportDto
    {
        [XmlElement("car")]
        public SaleCar  Car { get; set; }
        [XmlElement("discount")]
        public int Discount { get; set; }
        [XmlElement("customerName")]
        public string CustomerName { get; set; }
        [XmlElement("price")]
        public decimal Price { get; set; }
        [XmlElement("priceWithDiscount")]
        public decimal PriceWithDiscount { get; set; }
    }
    public class SaleCar
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int TraveledDistance { get; set; }


    }
}
