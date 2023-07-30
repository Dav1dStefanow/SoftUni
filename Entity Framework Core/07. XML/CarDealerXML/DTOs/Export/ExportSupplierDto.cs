using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CarDealerXML.DTOs.Export
{
    [XmlType("supplier")]
    public class ExportSupplierDto
    {

        [XmlAttribute("id")]
        public int Id { get; set; }
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlAttribute("parts-count")]
        public int PartsCount { get; set; }
    }
}
