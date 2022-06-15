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
    public class EProducto : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.ToTable("tb_producto");

            builder.HasKey(p => p.producto_id);

            builder
                .HasMany(p => p.DetalleVentas)
                .WithOne(dv=> dv.Producto);

            builder
                .HasMany(p => p.Carritos)
                .WithOne(car => car.Producto);
        }
    }
}
