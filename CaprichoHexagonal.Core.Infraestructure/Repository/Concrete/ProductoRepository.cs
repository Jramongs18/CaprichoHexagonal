using System;
using System.Collections.Generic;
using System.Text;

using CaprichoHexagonal.Core.Domain.Models;
using CaprichoHexagonal.Core.Infraestructure.Repository.Abstract;
using CaprichoHexagonal.Adaptors.SQLServerDataAccess.Contexts;

using System.Linq;

namespace CaprichoHexagonal.Core.Infraestructure.Repository.Concrete
{
    public class ProductoRepository : IBaseRepository<Producto, Guid>
    {
        private CaprichoDB db;

        public ProductoRepository(CaprichoDB db)
        {
            this.db = db;
        }
        public Producto Create(Producto producto)
        {
            producto.producto_id = Guid.NewGuid();

            db.Productos.Add(producto);
            return producto;
        }

        public void Delete(Guid entityId)
        {
            var selectedProducto = db.Productos
                .Where(p => p.producto_id == entityId).FirstOrDefault();

            if (selectedProducto != null)
                db.Productos.Remove(selectedProducto);
        }

        public List<Producto> GetAll()
        {
            return db.Productos.ToList();
        }

        public Producto GetById(Guid entityId)
        {
            var selectedProducto = db.Productos
                .Where(p => p.producto_id == entityId).FirstOrDefault();
            return selectedProducto;
        }

        public void saveAllChanges()
        {
            db.SaveChanges();
        }

        public Producto Update(Producto producto)
        {
            var selectedProducto = db.Productos
                .Where(p => p.producto_id == producto.producto_id)
                .FirstOrDefault();

            if (selectedProducto != null)
            {
                selectedProducto.nombre = producto.nombre;
                selectedProducto.descripcion = producto.descripcion;
                selectedProducto.marca_id = producto.marca_id;
                selectedProducto.categoria_id = producto.categoria_id;
                selectedProducto.precio = producto.precio;
                selectedProducto.stock = producto.stock;
                selectedProducto.ruta_imagen = producto.ruta_imagen;
                selectedProducto.nombre_imagen = producto.nombre_imagen;
                selectedProducto.activo = producto.activo;
                selectedProducto.fecha_registro = DateTime.Now;


                db.Entry(selectedProducto).State =
                    Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            return selectedProducto;
        }
    }
}
