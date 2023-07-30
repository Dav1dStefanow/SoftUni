using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CarDealerXML.DTOs.Import
{
    [XmlType("Car")]
    public class CarInputModel
    {
        [XmlElement("make")]
        public string Make { get; set; }
        [XmlElement("model")]
        public string Model { get; set; }
        [XmlElement("traveledDistance")]
        public int TraveledDistance { get; set; }
        [XmlArray("parts")]
        public ImportCarParts[] Parts { get; set; }
    }
    public class ImportCarParts
    {
        [XmlAttribute("partId")]
        public int Id { get; set; }
    }
}
