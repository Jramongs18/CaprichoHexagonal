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
    public class EDetalleVenta : IEntityTypeConfiguration<DetalleVenta>
    {
        public void Configure(EntityTypeBuilder<DetalleVenta> builder)
        {
            builder.ToTable("tb_detalleventa");

            builder.HasKey(dv => new { dv.venta_id, dv.producto_id });

            builder
                .HasOne(dv => dv.Producto)
                .WithMany(p => p.DetalleVentas);

            builder
                .HasOne(dv => dv.Venta)
                .WithMany(v => v.DetalleVentas);
        }
    }
}
