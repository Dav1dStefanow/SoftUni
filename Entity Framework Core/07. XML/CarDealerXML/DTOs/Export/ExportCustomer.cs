using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CarDealerXML.DTOs.Export
{
    [XmlType("customer")]
    public class ExportCustomer
    {
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("boughtCars")]
        public int BoughtCars { get; set; }
        [XmlElement("spentMoney")]
        public decimal SpentMoney { get; set; }
    }
}
