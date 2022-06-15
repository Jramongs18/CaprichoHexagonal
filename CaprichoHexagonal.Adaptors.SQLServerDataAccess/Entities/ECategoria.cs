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
    public class ECategoria : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("tb_categoria");

            builder.HasKey(cat => cat.categoria_id);

            builder
                .HasMany(cat => cat.Productos)
                .WithOne(p => p.Categoria);
        }
    }
}
