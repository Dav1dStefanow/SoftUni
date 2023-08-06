namespace Footballers.Data
{
    using EFExam06._04._2022.Data;
    using EFExam06._04._2022.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;

    public class FootballersContext : DbContext
    {
        public FootballersContext() { }

        public FootballersContext(DbContextOptions options)
            : base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TeamFootballerConfig());
        }

        public DbSet<Footballer> Footballers { get; set; }

        public DbSet<Team> Teams { get; set; } 

        public DbSet<Coach> Coaches { get; set; }

        public DbSet<TeamFootballer> TeamsFootballers { get; set; }
    }
}
