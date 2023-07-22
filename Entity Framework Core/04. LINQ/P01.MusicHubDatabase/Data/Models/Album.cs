﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.MusicHubDatabase.Data.Models
{
    public class Album
    {
        public Album()
        {
            this.Songs = new HashSet<Song>();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Price => Songs.Sum(s => s.Price);
        public int ProducerId { get; set; }
        public Producer Producer { get; set; }
        public virtual ICollection<Song> Songs { get; set; }

    }
}
