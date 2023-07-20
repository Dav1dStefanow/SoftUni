using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P00.EntityFrameworkConstructionLecture.Model
{
    public class SliDoDbContext : DbContext
    {
        public SliDoDbContext()
        {

        }
        public SliDoDbContext(DbContextOptions options)
            : base(options) 
        { 
        
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS; Database=SliDo;
                Integrated Security=true; TrustServerCertificate=True;");
            }
        }
        public DbSet<Question> Question { get; set; }
        public DbSet<Comment> Comment { get; set; }
    }
}
