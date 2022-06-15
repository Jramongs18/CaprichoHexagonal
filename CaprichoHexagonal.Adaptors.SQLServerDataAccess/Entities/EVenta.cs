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
    public class EVenta : IEntityTypeConfiguration<Venta>
    {
        public void Configure(EntityTypeBuilder<Venta> builder)
        {
            builder.ToTable("tb_venta");

            builder.HasKey(v => v.venta_id);

            builder
                .HasMany(v => v.DetalleVentas)
                .WithOne(dv => dv.Venta);

        }
    }
}
