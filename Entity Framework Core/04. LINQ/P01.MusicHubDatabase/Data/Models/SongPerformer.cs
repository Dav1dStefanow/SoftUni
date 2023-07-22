using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.MusicHubDatabase.Data.Models
{
    public class SongPerformer
    {
        public int SongId { get; set; } 
        public int PerformerId { get; set;}
        public Performer Performer { get; set; }
        public Song Song { get; set; }
    }
}
