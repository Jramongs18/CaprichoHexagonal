using System;
using System.Collections.Generic;
using System.Text;

using CaprichoHexagonal.Core.Domain.Models;
using CaprichoHexagonal.Core.Infraestructure.Repository.Abstract;
using CaprichoHexagonal.Adaptors.SQLServerDataAccess.Contexts;

using System.Linq;

namespace CaprichoHexagonal.Core.Infraestructure.Repository.Concrete
{
    public class AdministradorRepository : IBaseRepository<Administrador, Guid>
    {
        private CaprichoDB db;

        public AdministradorRepository(CaprichoDB db)
        {
            this.db = db;
        }
        public Administrador Create(Administrador administrador)
        {
            administrador.administrador_id = Guid.NewGuid();

            db.Administradores.Add(administrador);
            return administrador;
        }

        public void Delete(Guid entityId)
        {
            var selectedAdministrador = db.Administradores
                .Where(admin => admin.administrador_id == entityId).FirstOrDefault();

            if (selectedAdministrador != null)
                db.Administradores.Remove(selectedAdministrador);
        }

        public List<Administrador> GetAll()
        {
            return db.Administradores.ToList();
        }

        public Administrador GetById(Guid entityId)
        {
            var selectedAdministrador = db.Administradores
                .Where(admin => admin.administrador_id == entityId).FirstOrDefault();
            return selectedAdministrador;
        }

        public void saveAllChanges()
        {
            db.SaveChanges();
        }

        public Administrador Update(Administrador administrador)
        {
            var selectedAdministrador = db.Administradores
                .Where(admin => admin.administrador_id == admin.administrador_id)
                .FirstOrDefault();

            if (selectedAdministrador != null)
            {
                selectedAdministrador.nombres = administrador.nombres;
                selectedAdministrador.apellidos = administrador.apellidos;
                selectedAdministrador.correo = administrador.correo;
                selectedAdministrador.clave = administrador.clave;
                selectedAdministrador.activo = administrador.activo;
                selectedAdministrador.fecha_registro = DateTime.Now;

                db.Entry(selectedAdministrador).State =
                    Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            return selectedAdministrador;
        }
    }
}
