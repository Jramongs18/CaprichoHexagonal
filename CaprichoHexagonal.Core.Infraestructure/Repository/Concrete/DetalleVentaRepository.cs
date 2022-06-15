using System;
using System.Collections.Generic;
using System.Text;

using CaprichoHexagonal.Core.Infraestructure.Repository.Abstract;
using CaprichoHexagonal.Core.Domain.Models;
using CaprichoHexagonal.Adaptors.SQLServerDataAccess.Contexts;
using System.Linq;

namespace CaprichoHexagonal.Core.Infraestructure.Repository.Concrete
{
    public class DetalleVentaRepository : IDetailRepository<DetalleVenta, Guid>
    {
        private CaprichoDB db;

        public DetalleVentaRepository(CaprichoDB db)
        {
            this.db = db;
        }
        public DetalleVenta Create(DetalleVenta entity)
        {
            db.DetalleVentas.Add(entity);
            return entity;
        }

        public List<DetalleVenta> GetDetailsByTransaction(Guid transactionId)
        {
            var selectedProductos = db.DetalleVentas
                .Where(dv => dv.venta_id == transactionId)
                .ToList();
            return selectedProductos;
        }

        public void Cancel(Guid transactionid)
        {
            var selectedProductos = GetDetailsByTransaction(transactionid);

            if (selectedProductos != null)
            {
                selectedProductos.ForEach(detail =>
                {
                    db.DetalleVentas.Remove(detail);
                });
            }
            else
                throw new NullReferenceException("No se han encontrado productos para eliminar...");
        }
        

        public void saveAllChanges()
        {
            db.SaveChanges();
        }
    }
}
