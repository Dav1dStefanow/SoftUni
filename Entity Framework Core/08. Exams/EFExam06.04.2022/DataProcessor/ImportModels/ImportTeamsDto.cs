using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFExam06._04._2022.DataProcessor.ImportModels
{
    public class ImportTeamsDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(40)]
        [RegularExpression(@"^[A-Za-z0-9\s\.\-]{3,}$")]
        public string Name { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string Nationality { get; set; }

        public int Trophies { get; set; }

        public IEnumerable<int> Footballers { get; set; }
    }
   
}
