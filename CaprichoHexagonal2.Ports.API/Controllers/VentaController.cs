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
    public class VentaController : ControllerBase
    {
        public VentaUseCase CreateService()
        {
            CaprichoDB db = new CaprichoDB();

            VentaRepository repository = new VentaRepository(db);

            VentaUseCase service = new VentaUseCase(repository);

            return service;
        }
        // GET: api/<VentaController>
        [HttpGet]
        public ActionResult<IEnumerable<Venta>> Get()
        {
            VentaUseCase service = CreateService();
            return Ok(service.GetAll());
        }

        // GET api/<VentaController>/5
        [HttpGet("{id}")]
        public ActionResult<Venta> Get(Guid id)
        {
            VentaUseCase service = CreateService();

            return Ok(service.GetById(id));
        }

        // POST api/<VentaController>
        [HttpPost]
        public ActionResult<Venta> Post([FromBody] Venta venta)
        {
            VentaUseCase service = CreateService();

            var result = service.Create(venta);

            return Ok(result);
        }

        // PUT api/<VentaController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Venta venta)
        {
            VentaUseCase service = CreateService();
            venta.venta_id = id;
            service.Update(venta);

            return Ok("Editado exitosamente");
        }

        // DELETE api/<VentaController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            VentaUseCase service = CreateService();
            service.Delete(id);
            return Ok("Eliminado exitosamente");
        }
    }
}
