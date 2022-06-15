using System;
using System.Collections.Generic;
using System.Text;

using CaprichoHexagonal.Core.Domain.Models;
using CaprichoHexagonal.Core.Infraestructure.Repository.Abstract;
using CaprichoHexagonal.Adaptors.SQLServerDataAccess.Contexts;

using System.Linq;

namespace CaprichoHexagonal.Core.Infraestructure.Repository.Concrete
{
    public class DepartamentoRepository : IBaseRepository<Departamento, Guid>
    {
        private CaprichoDB db;

        public DepartamentoRepository(CaprichoDB db)
        {
            this.db = db;
        }
        public Departamento Create(Departamento departamento)
        {
            departamento.departamento_id = Guid.NewGuid();

            db.Departamentos.Add(departamento);
            return departamento;
        }

        public void Delete(Guid entityId)
        {
            var selectedDepartamento = db.Departamentos
                .Where(dep => dep.departamento_id == entityId).FirstOrDefault();

            if (selectedDepartamento != null)

                db.Departamentos.Remove(selectedDepartamento);
        }

        public List<Departamento> GetAll()
        {
            return db.Departamentos.ToList();
        }

        public Departamento GetById(Guid entityId)
        {
            var selectedDepartamento = db.Departamentos
                .Where(dep => dep.departamento_id == entityId).FirstOrDefault();
            return selectedDepartamento;
        }

        public void saveAllChanges()
        {
            db.SaveChanges();
        }

        public Departamento Update(Departamento departamento)
        {
            var selectedDepartamento = db.Departamentos
                .Where(dep => dep.departamento_id == departamento.departamento_id)
                .FirstOrDefault();

            if (selectedDepartamento != null)
            {
                selectedDepartamento.descripcion = departamento.descripcion;

                db.Entry(selectedDepartamento).State =
                    Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            return selectedDepartamento;
        }
    }
}
