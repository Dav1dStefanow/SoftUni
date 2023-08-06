using C_DBAdvancedExam_04Dec2021.Models.Enumerators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace C_DBAdvancedExam_04Dec2021.DataProcessor.ImportModels
{
    [XmlType("Play")]
    public class ImportPlaysDto
    {
        [Required]
        [MinLength(4)]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        public string Duration { get; set; }

        [Required]
        public double Rating { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        [MaxLength(700)]
        public string Description { get; set; }

        [XmlElement("Screenwriter")]
        [Required]
        [MaxLength(30)]
        [MinLength(4)]
        public string ScreenWriter { get; set; }
    }
}
