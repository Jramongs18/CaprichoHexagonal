using System;
using System.Collections.Generic;
using System.Text;

using CaprichoHexagonal.Core.Domain.Models;
using CaprichoHexagonal.Core.Infraestructure.Repository.Abstract;
using CaprichoHexagonal.Adaptors.SQLServerDataAccess.Contexts;

using System.Linq;

namespace CaprichoHexagonal.Core.Infraestructure.Repository.Concrete
{
    public class MunicipioRepository : IBaseRepository<Municipio, Guid>
    {
        private CaprichoDB db;

        public MunicipioRepository(CaprichoDB db)
        {
            this.db = db;
        }

        public Municipio Create(Municipio municipio)
        {
            municipio.municipio_id = Guid.NewGuid();

            db.Municipios.Add(municipio);
            return municipio;
        }

        public void Delete(Guid entityId)
        {
            var selectedMunicipio = db.Municipios
                .Where(mun => mun.municipio_id == entityId).FirstOrDefault();

            if (selectedMunicipio != null)
                db.Municipios.Remove(selectedMunicipio);
        }

        public List<Municipio> GetAll()
        {
            return db.Municipios.ToList();
        }

        public Municipio GetById(Guid entityId)
        {
            var selectedMunicipio = db.Municipios
                .Where(mun => mun.municipio_id == entityId).FirstOrDefault();
            return selectedMunicipio;
        }

        public void saveAllChanges()
        {
            db.SaveChanges();
        }

        public Municipio Update(Municipio municipio)
        {
            var selectedMunicipio = db.Municipios
                .Where(mun => mun.municipio_id == municipio.municipio_id)
                .FirstOrDefault();

            if (selectedMunicipio != null)
            {
                selectedMunicipio.descripcion = municipio.descripcion;
                selectedMunicipio.departamento_id = municipio.departamento_id;

                db.Entry(selectedMunicipio).State =
                    Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            return selectedMunicipio;
        }
    }
}
