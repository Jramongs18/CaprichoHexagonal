using System;
using System.Collections.Generic;
using System.Text;

using CaprichoHexagonal.Core.Domain.Models;
using CaprichoHexagonal.Core.Application.Interfaces;
using CaprichoHexagonal.Core.Infraestructure.Repository.Abstract;

namespace CaprichoHexagonal.Core.Application.UseCases
{
    public class CategoriaUseCase : IBaseUseCase<Categoria, Guid>
    {
        private readonly IBaseRepository<Categoria, Guid> repository;

        public CategoriaUseCase(IBaseRepository<Categoria, Guid> repository)
        {
            this.repository = repository;
        }
        public Categoria Create(Categoria entity)
        {
            if (entity != null)
            {
                var result = repository.Create(entity);
                repository.saveAllChanges();
                return result;
            }
            else
                throw new Exception("Error. La categoría no puede ser nula");
        }

        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
            repository.saveAllChanges();
        }

        public List<Categoria> GetAll()
        {
            return repository.GetAll();
        }

        public Categoria GetById(Guid entityId)
        {
            return repository.GetById(entityId);
        }

        public Categoria Update(Categoria entity)
        {
            repository.Update(entity);
            repository.saveAllChanges();
            return entity;
        }
    }
}
