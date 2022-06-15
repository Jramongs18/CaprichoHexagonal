using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CaprichoHexagonal.Core.Domain.Models;

namespace CaprichoHexagonal.Adaptors.SQLServerDataAccess.Entities
{
    public class EAdministrador : IEntityTypeConfiguration<Administrador>
    {
        public void Configure(EntityTypeBuilder<Administrador> builder)
        {
            builder.ToTable("tb_administrador");

            builder.HasKey(admin => admin.administrador_id);
        }
    }
}
