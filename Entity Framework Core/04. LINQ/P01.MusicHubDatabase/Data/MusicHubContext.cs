using Microsoft.EntityFrameworkCore;
using P01.MusicHubDatabase.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.MusicHubDatabase.Data
{
    public class MusicHubContext : DbContext
    {
        public MusicHubContext()
        {

        }
        public MusicHubContext(DbContextOptions options)
            : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS; Integrated Security=true;
                Database=MusicHub; TrustServerCertificate=True;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Song>(entity =>
            {
                entity.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(20);

                entity.HasKey(p => p.Id);

                entity.Property(p => p.Duration)
                .IsRequired();

                entity.Property(p => p.CreatedOn)
                .IsRequired();

                entity.Property(p => p.Genre)
                .IsRequired();

                entity.Property(p => p.Price)
                .IsRequired();

                /*entity.HasOne(p => p.Album)
                .WithMany(p => p.Songs)
                .HasForeignKey(p => p.AlbumId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(p => p.Writer)
                .WithMany(p => p.Songs)
                .HasForeignKey(p => p.WriterId)
                .OnDelete(DeleteBehavior.Restrict);*/
            });

            modelBuilder.Entity<Album>(entity =>
            {
                entity.HasKey(k  => k.Id);

                entity.Property(p => p.Name)
                .HasMaxLength(40)
                .IsRequired();

                entity.Property(p => p.ReleaseDate)
                .IsRequired();

                /*entity.HasOne(k => k.Producer)
                .WithMany(k => k.Albums)
                .HasForeignKey(k => k.ProducerId)
                .OnDelete(DeleteBehavior.Restrict);*/
            });

            modelBuilder.Entity<Performer>(entity =>
            {
                entity.HasKey(k => k.Id);

                entity.Property(p => p.FirstName)
                .HasMaxLength(20)
                .IsRequired();

                entity.Property(p => p.LastName)
                .HasMaxLength(20)
                .IsRequired();

                entity.Property(p => p.Age)
                .IsRequired();
                entity.Property(p => p.NetWorth)
               .IsRequired();

            });

            modelBuilder.Entity<Producer>(entity =>
            {
                entity.HasKey(k => k.Id);

                entity.Property(p => p.Name)
                .HasMaxLength(30)
                .IsRequired();
            });

            modelBuilder.Entity<Writer>(entity =>
            {
                entity.HasKey(k => k.Id);

                entity.Property(p => p.Name)
                .HasMaxLength(20)
                .IsRequired();
            });

            modelBuilder.Entity<SongPerformer>(entity =>
            {
                entity.HasKey(k => new {k.PerformerId, k.SongId });

                entity.HasOne(k => k.Performer)
                .WithMany(p =>  p.Performers)
                .HasForeignKey(k => k.PerformerId)
                .OnDelete(DeleteBehavior.Restrict);

                /*entity.HasOne(k => k.Song)
                .WithMany(s => s.SongPerformer)
                .HasForeignKey(k => k.PerformerId)
                .OnDelete(DeleteBehavior.Restrict);*/
            });
        }

        public DbSet<Producer> Producers { get; set;}
        public DbSet<Writer> Writers { get; set;}
        public DbSet<SongPerformer> SongPerformers { get;}
        public DbSet<Song> Songs { get; set;}
        public DbSet<Performer> Performers { get; set;}
        public DbSet<Album> Albums { get; set;}
    }
}
