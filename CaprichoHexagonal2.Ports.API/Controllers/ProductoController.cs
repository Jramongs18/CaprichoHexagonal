using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CaprichoHexagonal.Adaptors.SQLServerDataAccess.Contexts;
using CaprichoHexagonal.Core.Application.UseCases;
using CaprichoHexagonal.Core.Infraestructure.Repository.Concrete;

using CaprichoHexagonal.Core.Domain.Models;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CaprichoHexagonal.Ports.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        public ProductoUseCase CreateService()
        {
            CaprichoDB db = new CaprichoDB();

            ProductoRepository repository = new ProductoRepository(db);

            ProductoUseCase service = new ProductoUseCase(repository);

            return service;
        }
        // GET: api/<ProductoController>
        [HttpGet]
        public ActionResult<IEnumerable<Producto>> Get()
        {
            ProductoUseCase service = CreateService();
            return Ok(service.GetAll());
        }

        // GET api/<ProductoController>/5
        [HttpGet("{id}")]
        public ActionResult<Producto> Get(Guid id)
        {
           ProductoUseCase service = CreateService();

            return Ok(service.GetById(id));
        }

        // POST api/<ProductoController>
        [HttpPost]
        public ActionResult<Producto> Post([FromBody] Producto producto)
        {
            ProductoUseCase service = CreateService();

            var result = service.Create(producto);

            return Ok(result);
        }

        // PUT api/<ProductoController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Producto producto)
        {
            ProductoUseCase service = CreateService();
            producto.producto_id = id;
            service.Update(producto);

            return Ok("Editado exitosamente");
        }

        // DELETE api/<ProductoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            ProductoUseCase service = CreateService();
            service.Delete(id);
            return Ok("Eliminado exitosamente");
        }
    }
}
