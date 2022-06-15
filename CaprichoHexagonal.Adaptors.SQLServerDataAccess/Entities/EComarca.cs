using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CaprichoHexagonal.Core.Domain.Models;

namespace CaprichoHexagonal.Adaptors.SQLServerDataAccess.Entities
{
    public class EComarca : IEntityTypeConfiguration<Comarca>
    {
        public void Configure(EntityTypeBuilder<Comarca> builder)
        {
            builder.ToTable("tb_comarca");

            builder.HasKey(com => com.comarca_id);
        }
    }
}
