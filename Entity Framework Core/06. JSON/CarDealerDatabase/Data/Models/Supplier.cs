﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealerDatabase.Data.Models
{
    public class Supplier
    {
        public Supplier() 
        { 
            this.SupplierParts = new HashSet<Part>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsImporter { get; set; }
        public virtual ICollection<Part> SupplierParts { get; set;}
    }
}
