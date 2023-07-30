using Microsoft.EntityFrameworkCore;
using ProductShopDatabase.Data.Configurations;
using ProductShopDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShopDatabase.Data
{
    public class ProductShopContext : DbContext
    {
        public ProductShopContext() { }

        public ProductShopContext(DbContextOptions options) :base(options){ }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS; Database=ProductShopXML;
                Integrated Security=true; TrustServerCertificate=true;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryProductsConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; } 
        public DbSet<CategoryProducts> CategoriesProducts { get; set; }
    }
}
