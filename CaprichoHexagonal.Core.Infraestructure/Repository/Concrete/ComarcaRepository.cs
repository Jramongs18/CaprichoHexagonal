using System;
using System.Collections.Generic;
using System.Text;

using CaprichoHexagonal.Core.Domain.Models;
using CaprichoHexagonal.Core.Infraestructure.Repository.Abstract;
using CaprichoHexagonal.Adaptors.SQLServerDataAccess.Contexts;

using System.Linq;

namespace CaprichoHexagonal.Core.Infraestructure.Repository.Concrete
{
    public class ComarcaRepository : IBaseRepository<Comarca, Guid>
    {
        private CaprichoDB db;

        public ComarcaRepository(CaprichoDB db)
        {
            this.db = db;
        }
        public Comarca Create(Comarca comarca)
        {
            comarca.comarca_id = Guid.NewGuid();
            db.Comarcas.Add(comarca);
            return comarca;
        }

        public void Delete(Guid entityId)
        {
            var selectedComarca = db.Comarcas
                .Where(com => com.comarca_id == entityId).FirstOrDefault();

            if (selectedComarca != null)
                db.Comarcas.Remove(selectedComarca);
        }

        public List<Comarca> GetAll()
        {
            return db.Comarcas.ToList();
        }

        public Comarca GetById(Guid entityId)
        {
            var selectedComarca = db.Comarcas
                .Where(com => com.comarca_id == entityId).FirstOrDefault();
            return selectedComarca;
        }

        public void saveAllChanges()
        {
            db.SaveChanges();
        }

        public Comarca Update(Comarca comarca)
        {
            var selectedComarca=db.Comarcas
                .Where(com => com.comarca_id == comarca.comarca_id)
                .FirstOrDefault();

            if (selectedComarca != null)
            {
                selectedComarca.descripcion = comarca.descripcion;
                selectedComarca.municipio_id = comarca.municipio_id;

                db.Entry(selectedComarca).State =
                    Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            return selectedComarca;
        }
    }
}
