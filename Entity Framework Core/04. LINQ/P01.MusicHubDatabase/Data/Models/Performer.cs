using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.MusicHubDatabase.Data.Models
{
    public class Performer
    {
        public Performer()
        {
            this.Performers = new HashSet<SongPerformer>();
        }
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public decimal NetWorth { get; set; }
        public ICollection<SongPerformer> Performers { get; set;}

    }
}
