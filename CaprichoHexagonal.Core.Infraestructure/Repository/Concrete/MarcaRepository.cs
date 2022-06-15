using System;
using System.Collections.Generic;
using System.Text;

using CaprichoHexagonal.Core.Domain.Models;
using CaprichoHexagonal.Core.Infraestructure.Repository.Abstract;
using CaprichoHexagonal.Adaptors.SQLServerDataAccess.Contexts;

using System.Linq;

namespace CaprichoHexagonal.Core.Infraestructure.Repository.Concrete
{
    public class MarcaRepository : IBaseRepository<Marca, Guid>
    {
        private CaprichoDB db;

        public MarcaRepository(CaprichoDB db)
        {
            this.db = db;
        }
        public Marca Create(Marca marca)
        {
            marca.marca_id = Guid.NewGuid();

            db.Marcas.Add(marca);
            return marca;
        }

        public void Delete(Guid entityId)
        {
            var selectedMarca = db.Marcas
                .Where(mar => mar.marca_id == entityId).FirstOrDefault();

            if (selectedMarca != null)

                db.Marcas.Remove(selectedMarca);
        }

        public List<Marca> GetAll()
        {
            return db.Marcas.ToList();
        }

        public Marca GetById(Guid entityId)
        {
            var selectedMarca = db.Marcas
                .Where(mar => mar.marca_id == entityId).FirstOrDefault();
            return selectedMarca;
        }

        public void saveAllChanges()
        {
            db.SaveChanges();
        }

        public Marca Update(Marca marca)
        {
            var selectedMarca = db.Marcas
                .Where(mar => mar.marca_id == marca.marca_id)
                .FirstOrDefault();

            if (selectedMarca != null)
            {
                selectedMarca.descripcion = marca.descripcion;
                selectedMarca.activo = marca.activo;
                selectedMarca.fecha_registro = DateTime.Now;

                db.Entry(selectedMarca).State =
                    Microsoft.EntityFrameworkCore.EntityState.Modified;

            }
            return selectedMarca;
        }
    }
}
