using System;
using System.Collections.Generic;
using System.Text;

using CaprichoHexagonal.Core.Domain.Models;
using CaprichoHexagonal.Core.Infraestructure.Repository.Abstract;
using CaprichoHexagonal.Adaptors.SQLServerDataAccess.Contexts;

using System.Linq;

namespace CaprichoHexagonal.Core.Infraestructure.Repository.Concrete
{
    public class CategoriaRepository : IBaseRepository<Categoria, Guid>
    {
        private CaprichoDB db;

        public CategoriaRepository(CaprichoDB db)
        {
            this.db = db;
        }
        public Categoria Create(Categoria categoria)
        {
            categoria.categoria_id = Guid.NewGuid();

            db.Categorias.Add(categoria);
            return categoria;
        }

        public void Delete(Guid entityId)
        {
            var selectedCategoria = db.Categorias
                .Where(cat => cat.categoria_id == entityId).FirstOrDefault();

            if (selectedCategoria != null)
                db.Categorias.Remove(selectedCategoria);
        }

        public List<Categoria> GetAll()
        {
            return db.Categorias.ToList();
        }

        public Categoria GetById(Guid entityId)
        {
            var selectedCategoria = db.Categorias
                .Where(cat => cat.categoria_id == entityId).FirstOrDefault();
            return selectedCategoria;
        }

        public void saveAllChanges()
        {
            db.SaveChanges();
        }

        public Categoria Update(Categoria categoria)
        {
            var selectedCategoria = db.Categorias
                .Where(cat => cat.categoria_id == categoria.categoria_id)
                .FirstOrDefault();

            if (selectedCategoria != null)
            {
                selectedCategoria.descripcion = categoria.descripcion;
                selectedCategoria.activo = categoria.activo;
                selectedCategoria.fecha_registro = DateTime.Now;

                db.Entry(selectedCategoria).State =
                    Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            return selectedCategoria;
        }
    }
}
