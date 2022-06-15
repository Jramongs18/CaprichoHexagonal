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
    public class AdministradorController : ControllerBase
    {

        public AdministradorUseCase CreateService()
        {
            CaprichoDB db = new CaprichoDB();

            AdministradorRepository repository = new AdministradorRepository(db);

            AdministradorUseCase service = new AdministradorUseCase(repository);

            return service;
        }
        // GET: api/<AdministradorController>
        [HttpGet]
        public ActionResult<IEnumerable<Administrador>> Get()
        {
            AdministradorUseCase service = CreateService();
            return Ok(service.GetAll());
        }

        // GET api/<AdministradorController>/5
        [HttpGet("{id}")]
        public ActionResult<Administrador> Get(Guid id)
        {
            AdministradorUseCase service = CreateService();

            return Ok(service.GetById(id));
        }

        // POST api/<AdministradorController>
        [HttpPost]
        public ActionResult<Administrador> Post([FromBody] Administrador administrador)
        {
            AdministradorUseCase service = CreateService();

            var result = service.Create(administrador);

            return Ok(result);
        }

        // PUT api/<AdministradorController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Administrador administrador)
        {
            AdministradorUseCase service = CreateService();
            administrador.administrador_id = id;
            service.Update(administrador);

            return Ok("Editado exitosamente");
        }

        // DELETE api/<AdministradorController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            AdministradorUseCase service = CreateService();
            service.Delete(id);
            return Ok("Eliminado exitosamente");
        }
    }
}
