using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using CaprichoHexagonal.Core.Domain.Models;
using CaprichoHexagonal.Adaptors.SQLServerDataAccess.Entities;
using CaprichoHexagonal.Adaptors.SQLServerDataAccess.Utils;

namespace CaprichoHexagonal.Adaptors.SQLServerDataAccess.Contexts
{
    public class CaprichoDB: DbContext
    {
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Carrito> Carritos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Comarca> Comarcas { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<DetalleVenta> DetalleVentas { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Municipio> Municipios { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Venta> Ventas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new EAdministrador());
            builder.ApplyConfiguration(new ECarrito());
            builder.ApplyConfiguration(new ECategoria());
            builder.ApplyConfiguration(new ECliente());
            builder.ApplyConfiguration(new EComarca());
            builder.ApplyConfiguration(new EDepartamento());
            builder.ApplyConfiguration(new EDetalleVenta());
            builder.ApplyConfiguration(new EMarca());
            builder.ApplyConfiguration(new EMunicipio());
            builder.ApplyConfiguration(new EProducto());
            builder.ApplyConfiguration(new EVenta());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(GlobalSetting.SqlServerConnectionString);
        }
    }
}
