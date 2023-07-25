using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductShopDatabase.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShopDatabase.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(k => k.Seller)
                .WithMany(k => k.Sellers)
                .HasForeignKey(k => k.SellerId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(k => k.Buyer)
               .WithMany(k => k.Buyers)
               .HasForeignKey(k => k.BuyerId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
