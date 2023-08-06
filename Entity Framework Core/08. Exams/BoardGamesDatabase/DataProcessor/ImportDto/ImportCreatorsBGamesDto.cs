using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BoardGamesDatabase.DataProcessor.ImportDto
{
    [XmlType("Creator")]
    public class ImportCreatorsBGamesDto
    {
        [Required]
        [MinLength(2)]
        [MaxLength(7)]
        public string FirstName { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(7)]
        public string LastName { get; set; }
        [XmlArray("Boardgames")]
        public BoardGames[] BoardGames { get; set; }
    }
    [XmlType("Boardgame")]
    public class BoardGames
    {
        [Required]
        [MinLength(10)]
        [MaxLength(20)]
        public string Name { get; set; }
        [Required]
        [Range(1, 10)]
        public double Rating { get; set; }
        [Required]
        [Range(2018, 2023)]
        public int YearPublished { get; set; }
        [Required]
        public int CategoryType { get; set; }
        [Required]
        public string Mechanics { get; set; }
    }

}
