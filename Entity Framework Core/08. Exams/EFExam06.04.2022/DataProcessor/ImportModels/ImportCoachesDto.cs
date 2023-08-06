using EFExam06._04._2022.Models.Enumerators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EFExam06._04._2022.DataProcessor.ImportModels
{
    [XmlType("Coach")]
    public class ImportCoachesDto
    {
        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string Name { get; set; }

        [Required]
        public string Nationality { get; set; }

        [XmlArray("Footballers")]
        public FootballerXml[] Footballers { get; set; }
    }
    [XmlType("Footballer")]
    public class FootballerXml
    {
        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string Name { get; set; }

        [Required]
        public string ContractStartDate { get; set; }

        [Required]
        public string ContractEndDate { get; set; }

        [Required]
        public int BestSkillType { get; set; }

        [Required]
        public int PositionType { get; set; }
    }
}
       
        
