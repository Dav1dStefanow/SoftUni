using CarDealerXML.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealerXML.Data.Configurations
{
    public class PartCarConfiguration : IEntityTypeConfiguration<PartCar>
    {
        public void Configure(EntityTypeBuilder<PartCar> builder)
        {
            builder.HasKey(x => new { x.CarId, x.PartId });
        }
    }
}
