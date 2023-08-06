using EFExam06._04._2022.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFExam06._04._2022.Data
{
    public class TeamFootballerConfig : IEntityTypeConfiguration<TeamFootballer>
    {
        public void Configure(EntityTypeBuilder<TeamFootballer> builder)
        {
            builder.HasKey(pk => new { pk.FootballerId, pk.TeamId });
        }
    }
}
