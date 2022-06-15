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
    public class MarcaController : ControllerBase
    {
        public MarcaUseCase CreateService()
        {
            CaprichoDB db = new CaprichoDB();

            MarcaRepository repository = new MarcaRepository(db);

            MarcaUseCase service = new MarcaUseCase(repository);

            return service;
        }
        // GET: api/<MarcaController>
        [HttpGet]
        public ActionResult<IEnumerable<Marca>> Get()
        {
            MarcaUseCase service = CreateService();
            return Ok(service.GetAll());
        }

        // GET api/<MarcaController>/5
        [HttpGet("{id}")]
        public ActionResult<Marca> Get(Guid id)
        {
            MarcaUseCase service = CreateService();

            return Ok(service.GetById(id));
        }

        // POST api/<MarcaController>
        [HttpPost]
        public ActionResult<Marca> Post([FromBody] Marca marca)
        {
            MarcaUseCase service = CreateService();

            var result = service.Create(marca);

            return Ok(result);
        }

        // PUT api/<MarcaController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Marca marca)
        {
            MarcaUseCase service = CreateService();
            marca.marca_id = id;
            service.Update(marca);

            return Ok("Editado exitosamente");
        }

        // DELETE api/<MarcaController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            MarcaUseCase service = CreateService();
            service.Delete(id);
            return Ok("Eliminado exitosamente");
        }
    }
}
