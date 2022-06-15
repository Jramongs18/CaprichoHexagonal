using System;
using System.Collections.Generic;
using System.Text;

using CaprichoHexagonal.Core.Domain.Models;
using CaprichoHexagonal.Core.Application.Interfaces;
using CaprichoHexagonal.Core.Infraestructure.Repository.Abstract;

namespace CaprichoHexagonal.Core.Application.UseCases
{
    public class ClienteUseCase : IBaseUseCase<Cliente, Guid>
    {
        private readonly IBaseRepository<Cliente, Guid> repository;

        public ClienteUseCase(IBaseRepository<Cliente, Guid> repository)
        {
            this.repository = repository;
        }
        public Cliente Create(Cliente entity)
        {
            if (entity != null)
            {
                var result = repository.Create(entity);
                repository.saveAllChanges();
                return result;
            }
            else
                throw new Exception("Error. El cliente no puede ser nulo");
        }

        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
            repository.saveAllChanges();
        }

        public List<Cliente> GetAll()
        {
            return repository.GetAll();
        }

        public Cliente GetById(Guid entityId)
        {
            return repository.GetById(entityId);
        }

        public Cliente Update(Cliente entity)
        {
            repository.Update(entity);
            repository.saveAllChanges();
            return entity;
        }
    }
}
