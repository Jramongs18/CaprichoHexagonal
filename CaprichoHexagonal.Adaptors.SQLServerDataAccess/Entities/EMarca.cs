using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CaprichoHexagonal.Core.Domain.Models;


namespace CaprichoHexagonal.Adaptors.SQLServerDataAccess.Entities
{
    public class EMarca : IEntityTypeConfiguration<Marca>
    {
        public void Configure(EntityTypeBuilder<Marca> builder)
        {
            builder.ToTable("tb_marca");

            builder.HasKey(mar => mar.marca_id);

            builder
                .HasMany(mar => mar.Productos)
                .WithOne(p => p.Marca);
        }
    }
}
