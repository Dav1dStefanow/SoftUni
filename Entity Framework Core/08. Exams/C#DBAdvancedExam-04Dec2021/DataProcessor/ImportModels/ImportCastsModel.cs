using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace C_DBAdvancedExam_04Dec2021.DataProcessor.ImportModels
{
    [XmlType("Cast")]
    public class ImportCastsModel
    {
        [Required]
        [MinLength(4)]
        [MaxLength(30)]
        public string FullName { get; set; }

        [Required]
        public bool IsMainCharacter { get; set; }

        [Required]
        [RegularExpression(@"[+][4]{2}(-)[0-9]{2}\1[0-9]{3}\1[0-9]{4}")]
        public string PhoneNumber { get; set; }

        [Required]
        public int PlayId { get; set; }
    }
}
