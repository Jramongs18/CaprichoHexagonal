using System;
using System.Collections.Generic;
using System.Text;

using CaprichoHexagonal.Core.Domain.Models;
using CaprichoHexagonal.Core.Application.Interfaces;
using CaprichoHexagonal.Core.Infraestructure.Repository.Abstract;

namespace CaprichoHexagonal.Core.Application.UseCases
{
    public class VentaUseCase : IBaseUseCase<Venta, Guid>
    {
        private readonly IBaseRepository<Venta, Guid> repository;

        public VentaUseCase(IBaseRepository<Venta, Guid> repository)
        {
            this.repository = repository;
        }
        public Venta Create(Venta entity)
        {
            if (entity != null)
            {
                var result = repository.Create(entity);
                repository.saveAllChanges();
                return result;
            }
            else
                throw new Exception("Error. La venta no puede ser nula");
        }

        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
            repository.saveAllChanges();
        }

        public List<Venta> GetAll()
        {
            return repository.GetAll();
        }

        public Venta GetById(Guid entityId)
        {
            return repository.GetById(entityId);
        }

        public Venta Update(Venta entity)
        {
            repository.Update(entity);
            repository.saveAllChanges();
            return entity;
        }
    }
}
