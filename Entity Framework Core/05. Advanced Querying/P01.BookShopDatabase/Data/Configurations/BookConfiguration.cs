using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P01.BookShopDatabase.Data.Models;

namespace P01.BookShopDatabase.Data.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(e => e.BookId);

            builder.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(e => e.ReleaseDate)
                .IsRequired(true);

            builder.HasOne(e => e.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(e => e.AuthorId);
        }
    }
}
