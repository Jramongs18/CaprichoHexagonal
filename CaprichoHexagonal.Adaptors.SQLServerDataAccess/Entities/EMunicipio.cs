using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CaprichoHexagonal.Core.Domain.Models;

namespace CaprichoHexagonal.Adaptors.SQLServerDataAccess.Entities
{
    public class EMunicipio : IEntityTypeConfiguration<Municipio>
    {
        public void Configure(EntityTypeBuilder<Municipio> builder)
        {
            builder.ToTable("tb_municipio");

            builder.HasKey(mun => mun.municipio_id);

            builder
                .HasMany(mun => mun.Comarcas)
                .WithOne(com => com.municipio);
        }
    }
}
