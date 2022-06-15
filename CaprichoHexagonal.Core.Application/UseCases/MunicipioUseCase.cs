using System;
using System.Collections.Generic;
using System.Text;

using CaprichoHexagonal.Core.Domain.Models;
using CaprichoHexagonal.Core.Application.Interfaces;
using CaprichoHexagonal.Core.Infraestructure.Repository.Abstract;

namespace CaprichoHexagonal.Core.Application.UseCases
{
    public class MunicipioUseCase : IBaseUseCase<Municipio, Guid>
    {
        private readonly IBaseRepository<Municipio, Guid> repository;

        public MunicipioUseCase(IBaseRepository<Municipio, Guid> repository)
        {
            this.repository = repository;
        }
        public Municipio Create(Municipio entity)
        {
            if (entity != null)
            {
                var result = repository.Create(entity);
                repository.saveAllChanges();
                return result;
            }
            else
                throw new Exception("Error. El municipio no puede ser nulo");
        }

        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
            repository.saveAllChanges();
        }

        public List<Municipio> GetAll()
        {
            return repository.GetAll();
        }

        public Municipio GetById(Guid entityId)
        {
            return repository.GetById(entityId);
        }

        public Municipio Update(Municipio entity)
        {
            repository.Update(entity);
            repository.saveAllChanges();
            return entity;
        }
    }
}
