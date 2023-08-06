using BoardGamesDatabase.Data.Models;
using BoardGamesDatabase.Data.Models.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesDatabase.Data
{
    public class BoardGamesContext : DbContext
    {
        public BoardGamesContext() { }

        public BoardGamesContext(DbContextOptions options) :base(options){ }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS; Database = Boardgames ; 
                Integrated Security = true; TrustServerCertificate = true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BoardGameSellerConfig());
        }

        public DbSet<BoardGame> BoardGames { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<BoardGameSeller> BoardGamesSellers { get; set; }
        public DbSet<Creator> Creators { get; set; }

    }
}
