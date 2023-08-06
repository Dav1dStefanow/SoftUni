using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesDatabase.DataProcessor.ImportDto
{
    public class ImportSellersDto
    {
        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string Address { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        [RegularExpression(@"(www\.[a-zA-Z0-9\-]{2,256}\.com)")]
        public string WebSite { get; set; }
        public IEnumerable<int> BoardGames { get; set; }
    }
}
