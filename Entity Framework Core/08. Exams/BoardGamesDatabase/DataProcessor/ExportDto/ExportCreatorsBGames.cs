using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BoardGamesDatabase.DataProcessor.ExportDto
{
    [XmlType("Creator")]
    public class ExportCreatorsBGames
    {
        public string CreatorName { get; set; }
        [XmlArray("Boardgames")]
        public BoardGameExport[] BoardGames { get; set; }

        [XmlAttribute]
        public int BoardGamesCount { get; set; }
    }
    [XmlType("Boardgame")]
    public class BoardGameExport
    {
        public string BoardgameName { get; set; }
        public int BoardgameYearPublished { get; set; }
    }
}
