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
    public class ECliente : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("tb_cliente");

            builder.HasKey(cli => cli.cliente_id);

            builder
                .HasMany(cli => cli.Ventas)
                .WithOne(v => v.Cliente);

            builder
                .HasMany(cli => cli.Carritos)
                .WithOne(car => car.Cliente);
        }
    }
}
