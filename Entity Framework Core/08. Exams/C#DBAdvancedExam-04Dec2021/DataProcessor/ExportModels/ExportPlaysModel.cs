using C_DBAdvancedExam_04Dec2021.Models.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace C_DBAdvancedExam_04Dec2021.DataProcessor.ExportModels
{
    [XmlType("Play")]
    public class ExportPlaysModel
    {
        [XmlAttribute]
        public string Title { get; set; }

        [XmlAttribute]
        public TimeSpan Duration { get; set; }

        [XmlAttribute]
        public string Rating { get; set; }

        [XmlAttribute]
        public Genre Genre { get; set; }

        [XmlArray("Actors")]
        public ActorXml[] Actors { get; set; }
    }
    [XmlType("Actor")]
    public class ActorXml
    {
        [XmlAttribute]
        public string FullName { get; set; }

        [XmlAttribute]
        public string MainCharacter { get; set; }
    }
}
