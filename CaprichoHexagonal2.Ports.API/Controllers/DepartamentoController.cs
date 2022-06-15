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
    public class DepartamentoController : ControllerBase
    {
        public DepartamentoUseCase CreateService()
        {
            CaprichoDB db = new CaprichoDB();

            DepartamentoRepository repository = new DepartamentoRepository(db);

            DepartamentoUseCase service = new DepartamentoUseCase(repository);

            return service;
        }
        // GET: api/<DepartamentoController>
        [HttpGet]
        public ActionResult<IEnumerable<Departamento>> Get()
        {
            DepartamentoUseCase service = CreateService();
            return Ok(service.GetAll());
        }

        // GET api/<DepartamentoController>/5
        [HttpGet("{id}")]
        public ActionResult<Departamento> Get(Guid id)
        {
            DepartamentoUseCase service = CreateService();

            return Ok(service.GetById(id));
        }

        // POST api/<DepartamentoController>
        [HttpPost]
        public ActionResult<Departamento> Post([FromBody] Departamento departamento)
        {
            DepartamentoUseCase service = CreateService();

            var result = service.Create(departamento);

            return Ok(result);
        }

        // PUT api/<DepartamentoController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Departamento departamento)
        {
            DepartamentoUseCase service = CreateService();
            departamento.departamento_id = id;
            service.Update(departamento);

            return Ok("Editado exitosamente");
        }

        // DELETE api/<DepartamentoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            DepartamentoUseCase service = CreateService();
            service.Delete(id);
            return Ok("Eliminado exitosamente");
        }
    }
}
