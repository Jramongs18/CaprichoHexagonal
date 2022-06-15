using System;
using System.Collections.Generic;
using System.Text;

using CaprichoHexagonal.Core.Domain.Models;
using CaprichoHexagonal.Core.Infraestructure.Repository.Abstract;
using CaprichoHexagonal.Adaptors.SQLServerDataAccess.Contexts;

using System.Linq;

namespace CaprichoHexagonal.Core.Infraestructure.Repository.Concrete
{
    public class CarritoRepository : IDetailRepository<Carrito, Guid>
    {
        private CaprichoDB db;

        public CarritoRepository(CaprichoDB db)
        {
            this.db = db;
        }
        public Carrito Create(Carrito entity)
        {
            db.Carritos.Add(entity);
            return entity;
        }

        public List<Carrito> GetDetailsByTransaction(Guid transactionId)
        {
            var selectedProductos = db.Carritos
                 .Where(car => car.cliente_id == transactionId)
                 .ToList();
            return selectedProductos;
        }

        public void Cancel(Guid transactionId)
        {
            var selectedProductos = GetDetailsByTransaction(transactionId);

            if (selectedProductos != null)
            {
                selectedProductos.ForEach(detail =>
                {
                    db.Carritos.Remove(detail);
                });
            }
            else
                throw new NullReferenceException("No se han encontrado productos para eliminar..."); 
        }

        public void saveAllChanges()
        {
            db.SaveChanges(); ;
        }
    }
}
