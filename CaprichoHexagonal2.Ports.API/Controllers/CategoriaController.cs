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
    public class CategoriaController : ControllerBase
    {
        public CategoriaUseCase CreateService()
        {
            CaprichoDB db = new CaprichoDB();

            CategoriaRepository repository = new CategoriaRepository(db);

            CategoriaUseCase service = new CategoriaUseCase(repository);

            return service;
        }
        // GET: api/<CategoriaController>
        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            CategoriaUseCase service = CreateService();
            return Ok(service.GetAll());
        }

        // GET api/<CategoriaController>/5
        [HttpGet("{id}")]
        public ActionResult<Categoria> Get(Guid id)
        {
            CategoriaUseCase service = CreateService();

            return Ok(service.GetById(id));
        }

        // POST api/<CategoriaController>
        [HttpPost]
        public ActionResult<Categoria> Post([FromBody] Categoria categoria)
        {
            CategoriaUseCase service = CreateService();

            var result = service.Create(categoria);

            return Ok(result);
        }

        // PUT api/<CategoriaController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Categoria categoria)
        {
            CategoriaUseCase service = CreateService();
            categoria.categoria_id = id;
            service.Update(categoria);

            return Ok("Editado exitosamente");
        }

        // DELETE api/<CategoriaController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            CategoriaUseCase service = CreateService();
            service.Delete(id);
            return Ok("Eliminado exitosamente");
        }
    }
}
