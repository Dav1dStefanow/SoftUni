using EFExam06._04._2022.Models;
using EFExam06._04._2022.Models.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EFExam06._04._2022.DataProcessor.ExportModels
{
    [XmlType("Coach")]
    public class ExportCoachesFootballersModel
    {
        [XmlAttribute("FootballersCount")]
        public int FootballersCount { get; set; }

        public string CoachName { get; set; }

        [XmlArray("Footballers")]
        public FootballerXml[] Footballers { get; set; }
    }
    [XmlType("Footballer")]
    public class FootballerXml
    {
        public string Name { get; set; }
        public Position Position { get; set; }
    }
}
