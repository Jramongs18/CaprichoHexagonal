using System;
using System.Collections.Generic;
using System.Text;

using CaprichoHexagonal.Core.Domain.Models;
using CaprichoHexagonal.Core.Application.Interfaces;
using CaprichoHexagonal.Core.Infraestructure.Repository.Abstract;

namespace CaprichoHexagonal.Core.Application.UseCases
{
    public class MarcaUseCase : IBaseUseCase<Marca, Guid>
    {
        private readonly IBaseRepository<Marca, Guid> repository;

        public MarcaUseCase(IBaseRepository<Marca, Guid> repository)
        {
            this.repository = repository;
        }
        public Marca Create(Marca entity)
        {
            if (entity != null)
            {
                var result = repository.Create(entity);
                repository.saveAllChanges();
                return result;
            }
            else
                throw new Exception("Error. La marca no puede ser nula");
        }

        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
            repository.saveAllChanges();
        }

        public List<Marca> GetAll()
        {
            return repository.GetAll();
        }

        public Marca GetById(Guid entityId)
        {
            return repository.GetById(entityId);
        }

        public Marca Update(Marca entity)
        {
            repository.Update(entity);
            repository.saveAllChanges();
            return entity;
        }
    }
}
