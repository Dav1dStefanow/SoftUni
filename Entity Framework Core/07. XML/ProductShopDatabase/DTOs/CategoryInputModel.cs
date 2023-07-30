using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProductShopDatabase.DTOs
{
    [XmlType("Category")]
    public class CategoryInputModel
    {
        [XmlElement("name")]
        public string Name { get; set; }
    }
}
