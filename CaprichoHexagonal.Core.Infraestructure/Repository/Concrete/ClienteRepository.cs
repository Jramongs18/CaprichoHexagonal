using System;
using System.Collections.Generic;
using System.Text;

using CaprichoHexagonal.Core.Domain.Models;
using CaprichoHexagonal.Core.Infraestructure.Repository.Abstract;
using CaprichoHexagonal.Adaptors.SQLServerDataAccess.Contexts;

using System.Linq;

namespace CaprichoHexagonal.Core.Infraestructure.Repository.Concrete
{
    public class ClienteRepository : IBaseRepository<Cliente, Guid>
    {

        private CaprichoDB db;

        public ClienteRepository(CaprichoDB db)
        {
            this.db = db;
        }
        public Cliente Create(Cliente cliente)
        {
            cliente.cliente_id = Guid.NewGuid();

            db.Clientes.Add(cliente);
            return cliente;
        }

        public void Delete(Guid entityId)
        {
            var selectedCliente = db.Clientes
                .Where(cli => cli.cliente_id == entityId).FirstOrDefault();

            if (selectedCliente != null)
                db.Clientes.Remove(selectedCliente);
        }

        public List<Cliente> GetAll()
        {
            return db.Clientes.ToList();
        }

        public Cliente GetById(Guid entityId)
        {
            var selectedCliente = db.Clientes
                .Where(cli => cli.cliente_id == entityId).FirstOrDefault();
            return selectedCliente;
        }

        public void saveAllChanges()
        {
            db.SaveChanges();
        }

        public Cliente Update(Cliente cliente)
        {
            var selectedCliente = db.Clientes
                .Where(cli => cli.cliente_id == cliente.cliente_id)
                .FirstOrDefault();

            if (selectedCliente != null)
            {
                selectedCliente.nombres = cliente.nombres;
                selectedCliente.apellidos = cliente.apellidos;
                selectedCliente.correo = cliente.correo;
                selectedCliente.clave = cliente.clave;
                selectedCliente.fecha_registro = DateTime.Now;
                selectedCliente.reestablecer = cliente.reestablecer;

                db.Entry(selectedCliente).State =
                    Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            return selectedCliente;
        }
    }
}
