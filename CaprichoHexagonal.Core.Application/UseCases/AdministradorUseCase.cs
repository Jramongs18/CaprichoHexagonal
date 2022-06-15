using System;
using System.Collections.Generic;
using System.Text;

using CaprichoHexagonal.Core.Domain.Models;
using CaprichoHexagonal.Core.Application.Interfaces;
using CaprichoHexagonal.Core.Infraestructure.Repository.Abstract;

namespace CaprichoHexagonal.Core.Application.UseCases
{
    public class AdministradorUseCase : IBaseUseCase<Administrador, Guid>
    {
        private readonly IBaseRepository<Administrador,Guid>repository;

        public AdministradorUseCase(IBaseRepository<Administrador, Guid> repository)
        {
            this.repository = repository;
        }
        public Administrador Create(Administrador entity)
        {
            if (entity != null)
            {
                var result = repository.Create(entity);
                repository.saveAllChanges();
                return result;
            }
            else
                throw new Exception("Error. El administrador no puede ser nulo");
        }

        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
            repository.saveAllChanges();
        }

        public List<Administrador> GetAll()
        {
            return repository.GetAll();
        }

        public Administrador GetById(Guid entityId)
        {
            return repository.GetById(entityId);
        }

        public Administrador Update(Administrador entity)
        {
            repository.Update(entity);
            repository.saveAllChanges();
            return entity;
        }
    }
}
