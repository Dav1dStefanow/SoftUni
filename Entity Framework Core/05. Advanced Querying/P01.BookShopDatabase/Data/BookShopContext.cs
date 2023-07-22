using Microsoft.EntityFrameworkCore;
using P01.BookShopDatabase.Data.Configurations;
using P01.BookShopDatabase.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.BookShopDatabase.Data
{
    public class BookShopContext : DbContext
    {
        public BookShopContext() { }
        public BookShopContext(DbContextOptions options) :base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS; Integrated Security=true;
                Database=BookShop; TrustServerCertificate=true;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new BookCategoryConfiguration());
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; } 
        public DbSet<BooksCategory> BooksCategories { get; set; }
    }
}
