using System;
using System.Collections.Generic;
using System.Text;

using CaprichoHexagonal.Core.Domain.Models;
using CaprichoHexagonal.Core.Infraestructure.Repository.Abstract;
using CaprichoHexagonal.Adaptors.SQLServerDataAccess.Contexts;

using System.Linq;

namespace CaprichoHexagonal.Core.Infraestructure.Repository.Concrete
{
    public class VentaRepository : IBaseRepository<Venta, Guid>
    {
        private CaprichoDB db;

        public VentaRepository(CaprichoDB db)
        {
            this.db = db;
        }

        public Venta Create(Venta venta)
        {
            venta.venta_id = Guid.NewGuid();

            db.Ventas.Add(venta);
            return venta;
        }

        public void Delete(Guid entityId)
        {
            var selectedVenta = db.Ventas
                .Where(v => v.venta_id == entityId).FirstOrDefault();

            if (selectedVenta != null)
                db.Ventas.Remove(selectedVenta);
        }

        public List<Venta> GetAll()
        {
            return db.Ventas.ToList();
        }

        public Venta GetById(Guid entityId)
        {
            var selectedVenta = db.Ventas
                .Where(v => v.venta_id == entityId).FirstOrDefault();
            return selectedVenta;
        }

        public void saveAllChanges()
        {
            db.SaveChanges();
        }

        public Venta Update(Venta venta)
        {
            var selectedVenta = db.Ventas
                .Where(v => v.venta_id == venta.venta_id)
                .FirstOrDefault();

            if (selectedVenta != null)
            {
                selectedVenta.cliente_id = venta.cliente_id;
                selectedVenta.total_producto = venta.total_producto;
                selectedVenta.monto_total = venta.monto_total;
                selectedVenta.contacto = venta.contacto;
                selectedVenta.comarca_id = venta.comarca_id;
                selectedVenta.telefono = venta.telefono;
                selectedVenta.transaccion_id = venta.transaccion_id;
                selectedVenta.fecha_venta = DateTime.Now;

                db.Entry(selectedVenta).State =
                    Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            return selectedVenta;
        }
    }
}
