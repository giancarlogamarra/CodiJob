using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodiJobServices.Model.CodiJobDb;
using CodiJobServices.Model.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodiJobServices.Controllers
{
    [Route("api/[controller]")]
    public class ProyectoController : Controller
    {
        private IProyectoRepository repositorio;
        public ProyectoController(IProyectoRepository repo) {
            repositorio = repo;
        }
        // GET: api/<controller>
        [HttpGet]
        public IQueryable<Tproyectos> Get()
        {
            return repositorio.Items;
        }

        // GET api/<controller>/5
        [HttpGet("{ProyectoId}")]
        public Tproyectos Get(Guid ProyectoId)
        {
            
            return repositorio.Items.Where(p => p.ProyectoId == ProyectoId).FirstOrDefault();
        }
  
        [HttpGet("{pageSize}/{page}")]
        public IQueryable<Tproyectos> Get(int pageSize, int page)
        {
            return repositorio.FilterProyectos(pageSize, page);
        }
        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]Tproyectos proyecto)
        {
            repositorio.Save(proyecto);
            return Ok(true);
        }

        // PUT api/<controller>/5
        [HttpPut("{ProyectoId}")]
        public IActionResult Put(Guid ProyectoId, [FromBody]Tproyectos proyecto)
        {
            proyecto.ProyectoId = ProyectoId;
            repositorio.Save(proyecto);
            return Ok(true);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{ProyectoId}")]
        public IActionResult Delete(Guid ProyectoId)
        {
           repositorio.Delete(ProyectoId);
           return Ok(true);
        }
    }
}
