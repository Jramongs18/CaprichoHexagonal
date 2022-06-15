using System;
using System.Collections.Generic;
using System.Text;

using CaprichoHexagonal.Core.Domain.Models;
using CaprichoHexagonal.Core.Application.Interfaces;
using CaprichoHexagonal.Core.Infraestructure.Repository.Abstract;

namespace CaprichoHexagonal.Core.Application.UseCases
{
    public class DetalleVentaCaseUse : IDetailUseCase<Venta, Guid>
    {
        private readonly IBaseRepository<Venta, Guid> ventaRepository;
        private readonly IDetailRepository<DetalleVenta, Guid> detalleventaRepository;

        public DetalleVentaCaseUse(
            IBaseRepository<Venta, Guid> ventaRepository,
            IDetailRepository<DetalleVenta, Guid> detalleventaRepository
            )
        {
            this.ventaRepository = ventaRepository;
            this.detalleventaRepository = detalleventaRepository;
        }
        public void Cancel(Guid entityId)
        {
            detalleventaRepository.Cancel(entityId);
            detalleventaRepository.saveAllChanges();

        }

        public Venta Create(Venta venta)
        {
            var createdVenta = ventaRepository.Create(venta);
            venta.DetalleVentas.ForEach(detail =>
            {
                detalleventaRepository.Create(detail);
            });
            ventaRepository.saveAllChanges();
            return createdVenta;
        }
    }
}
