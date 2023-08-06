
namespace Theatre.Data
{
    using C_DBAdvancedExam_04Dec2021.Models;
    using Microsoft.EntityFrameworkCore;

    public class TheatreContext : DbContext
    {
        public TheatreContext() 
        {

        }

        public TheatreContext(DbContextOptions options)
        : base(options) 
        { 

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        public DbSet<Cast> Casts { get; set; }

        public DbSet<Play> Plays { get; set; }

        public DbSet<Theatre> Theatres { get; set; }

        public DbSet<Ticket> Tickets { get; set; }
    }
}