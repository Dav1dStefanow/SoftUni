using CarDealerXML.Data.Configurations;
using CarDealerXML.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealerXML.Data
{
    public class CarDealerContext : DbContext
    {
        public CarDealerContext() { }

        public CarDealerContext(DbContextOptions options) :base(options){ }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS; Integrated Security=true;
                Database=CarDealerXML;  TrustServerCertificate=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PartCarConfiguration());
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<PartCar> PartsCars { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
    }
}
