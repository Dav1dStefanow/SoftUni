using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesDatabase.Data.Models
{
    public class BoardGameSeller
    {
        public int BoardGameId { get; set; }
        public BoardGame BoardGame { get; set; }
        public int SellerId { get; set; }
        public Seller Seller { get; set; }
    }
}
