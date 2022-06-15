using System;
using System.Collections.Generic;
using System.Text;

using CaprichoHexagonal.Core.Domain.Models;
using CaprichoHexagonal.Core.Application.Interfaces;
using CaprichoHexagonal.Core.Infraestructure.Repository.Abstract;

namespace CaprichoHexagonal.Core.Application.UseCases
{
    public class DepartamentoUseCase : IBaseUseCase<Departamento, Guid>
    {
        private readonly IBaseRepository<Departamento, Guid> repository;

        public DepartamentoUseCase(IBaseRepository<Departamento, Guid> repository)
        {
            this.repository = repository;
        }

        public Departamento Create(Departamento entity)
        {
            if (entity != null)
            {
                var result = repository.Create(entity);
                repository.saveAllChanges();
                return result;
            }
            else
                throw new Exception("Error. El departamento no puede ser nulo");
        }

        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
            repository.saveAllChanges();
        }

        public List<Departamento> GetAll()
        {
            return repository.GetAll();
        }

        public Departamento GetById(Guid entityId)
        {
            return repository.GetById(entityId);
        }

        public Departamento Update(Departamento entity)
        {
            repository.Update(entity);
            repository.saveAllChanges();
            return entity;
        }
    }
}
