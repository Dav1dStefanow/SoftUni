using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CarDealerXML.DTOs.Export
{
    [XmlType("part")]
    public class ExportPart
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlAttribute("price")]
        public decimal Price { get; set; }
        [XmlAttribute("quantity")]
        public int Quantity { get; set; }
        [XmlAttribute("supplierId")]
        public int SupplierId { get; set; }
    }
}
