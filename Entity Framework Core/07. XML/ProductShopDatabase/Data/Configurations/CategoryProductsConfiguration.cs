using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductShopDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShopDatabase.Data.Configurations
{
    public class CategoryProductsConfiguration : IEntityTypeConfiguration<CategoryProducts>
    {
        public void Configure(EntityTypeBuilder<CategoryProducts> builder)
        {
            builder.HasKey(k => new {k.ProductId, k.CategoryId});
            
        }
    }
}
