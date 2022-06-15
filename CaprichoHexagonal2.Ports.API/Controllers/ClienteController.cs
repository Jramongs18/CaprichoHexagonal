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


namespace CaprichoHexagonal.Ports.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        public ClienteUseCase CreateService()
        {
            CaprichoDB db = new CaprichoDB();

            ClienteRepository repository = new ClienteRepository(db);

            ClienteUseCase service = new ClienteUseCase(repository);

            return service;
        }
        // GET: api/<ClienteController>
        [HttpGet]
        public ActionResult<IEnumerable<Cliente>> Get()
        {
            ClienteUseCase service = CreateService();
            return Ok(service.GetAll());
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public ActionResult<Cliente>Get(Guid id)
        {
            ClienteUseCase service = CreateService();

            return Ok(service.GetById(id));
        }

        // POST api/<ClienteController>
        [HttpPost]
        public ActionResult<Cliente> Post([FromBody]Cliente cliente)
        {
            ClienteUseCase service = CreateService();

            var result = service.Create(cliente);

            return Ok(result);
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id,[FromBody] Cliente cliente)
        {
            ClienteUseCase service = CreateService();
            cliente.cliente_id = id;
            service.Update(cliente);

            return Ok("Editado exitosamente");
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            ClienteUseCase service = CreateService();
            service.Delete(id);
            return Ok("Eliminado exitosamente");
        }
    }
}
