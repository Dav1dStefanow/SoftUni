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
    internal class BookCategoryConfiguration : IEntityTypeConfiguration<BooksCategory>
    {
        public void Configure(EntityTypeBuilder<BooksCategory> builder)
        {
            builder.HasKey(e => new { e.BookId, e.CategoryId });

            builder.HasOne(e => e.Category)
                .WithMany(c => c.Categories)
                .HasForeignKey(e => e.CategoryId);

            builder.HasOne(e => e.Book)
                .WithMany(c => c.Books)
                .HasForeignKey(e => e.BookId);
        }
    }
}
