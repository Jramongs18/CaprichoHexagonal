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
    public class ECarrito : IEntityTypeConfiguration<Carrito>
    {
        public void Configure(EntityTypeBuilder<Carrito> builder)
        {
            builder.ToTable("tb_carrito");

            builder.HasKey(car => new { car.cliente_id, car.producto_id });

            builder
                .HasOne(car => car.Producto)
                .WithMany(p => p.Carritos);

            builder
                .HasOne(car => car.Cliente)
                .WithMany(cli => cli.Carritos);
        }
    }
}
