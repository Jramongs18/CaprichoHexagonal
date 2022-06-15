using System;
using System.Collections.Generic;
using System.Text;

using CaprichoHexagonal.Core.Domain.Models;
using CaprichoHexagonal.Core.Application.Interfaces;
using CaprichoHexagonal.Core.Infraestructure.Repository.Abstract;

namespace CaprichoHexagonal.Core.Application.UseCases
{
    public class ProductoUseCase : IBaseUseCase<Producto, Guid>
    {
        private readonly IBaseRepository<Producto, Guid> repository;

        public ProductoUseCase(IBaseRepository<Producto, Guid> repository)
        {
            this.repository = repository;
        }
        public Producto Create(Producto entity)
        {
            if (entity != null)
            {
                var result = repository.Create(entity);
                repository.saveAllChanges();
                return result;
            }
            else
                throw new Exception("Error. El producto no puede ser nulo");
        }

        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
            repository.saveAllChanges();
        }

        public List<Producto> GetAll()
        {
            return repository.GetAll();
        }

        public Producto GetById(Guid entityId)
        {
            return repository.GetById(entityId);
        }

        public Producto Update(Producto entity)
        {
            repository.Update(entity);
            repository.saveAllChanges();
            return entity;
        }
    }
}
