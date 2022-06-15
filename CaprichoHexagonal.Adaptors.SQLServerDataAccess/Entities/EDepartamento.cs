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
    public class EDepartamento : IEntityTypeConfiguration<Departamento>
    {
        public void Configure(EntityTypeBuilder<Departamento> builder)
        {
            builder.ToTable("tb_departamento");

            builder.HasKey(dep => dep.departamento_id);

            builder
                .HasMany(dep => dep.Municipios)
                .WithOne(mun => mun.Departamento);
        }
    }
}
