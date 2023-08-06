using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesDatabase.Data.Models.Configurations
{
    public class BoardGameSellerConfig : IEntityTypeConfiguration<BoardGameSeller>
    {
        public void Configure(EntityTypeBuilder<BoardGameSeller> builder)
        {
            builder.HasKey(k => new { k.SellerId, k.BoardGameId });
        }
    }
}
