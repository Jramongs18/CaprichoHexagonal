using System;
using System.Collections.Generic;
using System.Text;

using CaprichoHexagonal.Core.Domain.Models;
using CaprichoHexagonal.Core.Application.Interfaces;
using CaprichoHexagonal.Core.Infraestructure.Repository.Abstract;

namespace CaprichoHexagonal.Core.Application.UseCases
{
    public class CarritoUseCase : IDetailUseCase<Cliente, Guid>
    {
        private readonly IBaseRepository<Cliente, Guid> clienteRepository;
        private readonly IDetailRepository<Carrito, Guid> carritoRepository;

        public CarritoUseCase(
            IBaseRepository<Cliente,Guid>clienteRepository,
            IDetailRepository<Carrito,Guid>carritoRepository
            )
        {
            this.clienteRepository = clienteRepository;
            this.carritoRepository = carritoRepository;
        }
        public void Cancel(Guid entityId)
        {
            carritoRepository.Cancel(entityId);
            carritoRepository.saveAllChanges();
        }

        public Cliente Create(Cliente cliente)
        {
            var createdCliente = clienteRepository.Create(cliente);
            cliente.Carritos.ForEach(detail =>
            {
                carritoRepository.Create(detail);
            });
            clienteRepository.saveAllChanges();
            return createdCliente;
        }
    }
}
