using System;
using System.Collections.Generic;
using System.Text;

using CaprichoHexagonal.Core.Domain.Models;
using CaprichoHexagonal.Core.Application.Interfaces;
using CaprichoHexagonal.Core.Infraestructure.Repository.Abstract;

namespace CaprichoHexagonal.Core.Application.UseCases
{
    public class ComarcaUseCase : IBaseUseCase<Comarca, Guid>
    {
        private readonly IBaseRepository<Comarca, Guid> repository;

        public ComarcaUseCase(IBaseRepository<Comarca, Guid> repository)
        {
            this.repository = repository;
        }
        public Comarca Create(Comarca entity)
        {
            if (entity != null)
            {
                var result = repository.Create(entity);
                repository.saveAllChanges();
                return result;
            }
            else
                throw new Exception("Error. La comarca no puede ser nula");
        }

        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
            repository.saveAllChanges();
        }

        public List<Comarca> GetAll()
        {
            return repository.GetAll();
        }

        public Comarca GetById(Guid entityId)
        {
            return repository.GetById(entityId);
        }

        public Comarca Update(Comarca entity)
        {
            repository.Update(entity);
            repository.saveAllChanges();
            return entity;
        }
    }
}
