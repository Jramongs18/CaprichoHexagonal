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
    public class ComarcaController : ControllerBase
    {
        public ComarcaUseCase CreateService()
        {
            CaprichoDB db = new CaprichoDB();

            ComarcaRepository repository = new ComarcaRepository(db);

            ComarcaUseCase service = new ComarcaUseCase(repository);

            return service;
        }
        // GET: api/<ComarcaController>
        [HttpGet]
        public ActionResult<IEnumerable<Comarca>> Get()
        {
            ComarcaUseCase service = CreateService();
            return Ok(service.GetAll());
        }

        // GET api/<ComarcaController>/5
        [HttpGet("{id}")]
        public ActionResult<Comarca> Get(Guid id)
        {
            ComarcaUseCase service = CreateService();

            return Ok(service.GetById(id));
        }

        // POST api/<ComarcaController>
        [HttpPost]
        public ActionResult<Cliente> Post([FromBody] Comarca comarca)
        {
            ComarcaUseCase service = CreateService();

            var result = service.Create(comarca);

            return Ok(result);
        }

        // PUT api/<ComarcaController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Comarca comarca)
        {
            ComarcaUseCase service = CreateService();
            comarca.comarca_id = id;
            service.Update(comarca);

            return Ok("Editado exitosamente");
        }

        // DELETE api/<ComarcaController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            ComarcaUseCase service = CreateService();
            service.Delete(id);
            return Ok("Eliminado exitosamente");
        }
    }
}
